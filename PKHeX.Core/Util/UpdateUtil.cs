using System;
using System.Text.Json;

namespace PKHeX.Core;

public static class UpdateUtil
{
    /// <summary>
    /// Gets the latest GitHub release version and tag name
    /// </summary>
    /// <returns>A tuple containing the parsed version and the original tag name, or null if the latest version could not be determined</returns>
    public static (Version Version, string TagName)? GetLatestGitHubRelease()
    {
        const string apiEndpoint = "https://api.github.com/repos/NexusRisen/PKHeXth/releases/latest";
        var responseJson = NetUtil.GetStringFromURL(new Uri(apiEndpoint));
        if (responseJson is null)
            return null;

        // Parse it manually; no need to parse the entire json to object.
        const string tag = "tag_name";
        var index = responseJson.IndexOf(tag, StringComparison.Ordinal);
        if (index == -1)
            return null;

        var first = responseJson.IndexOf('"', index + tag.Length + 1) + 1;
        if (first == 0)
            return null;
        var second = responseJson.IndexOf('"', first);
        if (second == -1)
            return null;

        var tagString = responseJson[first..second];
        var originalTag = tagString;

        // Strip 'v' prefix and anything after '-' (like '-test', '-changelog') for version parsing
        if (tagString.StartsWith('v'))
            tagString = tagString[1..];
        var dashIndex = tagString.IndexOf('-');
        if (dashIndex > 0)
            tagString = tagString[..dashIndex];

        return !Version.TryParse(tagString, out var latestVersion) ? null : (latestVersion, originalTag);
    }

    /// <summary>
    /// Gets the latest version of PKHeX according to the GitHub API
    /// </summary>
    /// <returns>A version representing the latest available version of PKHeX, or null if the latest version could not be determined</returns>
    public static Version? GetLatestPKHeXVersion()
    {
        return GetLatestGitHubRelease()?.Version;
    }

    /// <summary>
    /// Gets the download URL for the latest PKHeX release
    /// </summary>
    /// <returns>The download URL for the latest PKHeX.exe, or null if it could not be determined</returns>
    public static string? GetLatestDownloadURL()
    {
        const string apiEndpoint = "https://api.github.com/repos/NexusRisen/PKHeXth/releases/latest";
        var responseJson = NetUtil.GetStringFromURL(new Uri(apiEndpoint));
        if (responseJson is null)
            return null;

        try
        {
            using var document = JsonDocument.Parse(responseJson);
            var root = document.RootElement;
            if (!root.TryGetProperty("assets", out var assetsElement))
                return null;

            foreach (var asset in assetsElement.EnumerateArray())
            {
                if (asset.TryGetProperty("name", out var nameElement) &&
                    nameElement.GetString() == "PKHeX.exe" &&
                    asset.TryGetProperty("browser_download_url", out var urlElement))
                {
                    return urlElement.GetString();
                }
            }
            return null;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Gets the changelog/release notes for the latest PKHeX release
    /// </summary>
    /// <returns>The changelog text, or null if it could not be determined</returns>
    public static string? GetLatestChangelog()
    {
        const string apiEndpoint = "https://api.github.com/repos/NexusRisen/PKHeXth/releases/latest";
        var responseJson = NetUtil.GetStringFromURL(new Uri(apiEndpoint));
        if (responseJson is null)
            return null;

        try
        {
            using var document = JsonDocument.Parse(responseJson);
            var root = document.RootElement;
            if (root.TryGetProperty("body", out var bodyElement))
            {
                var rawChangelog = bodyElement.GetString();
                return FormatChangelog(rawChangelog);
            }
            return null;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Formats the raw changelog text into a more structured and formal presentation
    /// </summary>
    /// <param name="rawChangelog">The raw changelog text from GitHub</param>
    /// <returns>Formatted changelog text</returns>
    private static string? FormatChangelog(string? rawChangelog)
    {
        if (string.IsNullOrWhiteSpace(rawChangelog))
            return rawChangelog;

        var lines = rawChangelog.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        var formatted = new System.Text.StringBuilder();

        formatted.AppendLine("═══════════════════════════════════════════════════════════════");
        formatted.AppendLine("                         RELEASE NOTES");
        formatted.AppendLine("═══════════════════════════════════════════════════════════════");
        formatted.AppendLine();

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();

            // Skip empty lines
            if (string.IsNullOrWhiteSpace(trimmedLine))
            {
                formatted.AppendLine();
                continue;
            }

            // Format section headers (lines that start with ## or single #)
            if (trimmedLine.StartsWith("## "))
            {
                formatted.AppendLine();
                formatted.AppendLine("───────────────────────────────────────────────────────────────");
                formatted.AppendLine($"  {trimmedLine[3..].ToUpperInvariant()}");
                formatted.AppendLine("───────────────────────────────────────────────────────────────");
                formatted.AppendLine();
            }
            else if (trimmedLine.StartsWith("# "))
            {
                formatted.AppendLine();
                formatted.AppendLine("═══════════════════════════════════════════════════════════════");
                formatted.AppendLine($"  {trimmedLine[2..].ToUpperInvariant()}");
                formatted.AppendLine("═══════════════════════════════════════════════════════════════");
                formatted.AppendLine();
            }
            // Format bullet points
            else if (trimmedLine.StartsWith("- ") || trimmedLine.StartsWith("* "))
            {
                formatted.AppendLine($"  • {trimmedLine[2..]}");
            }
            // Format numbered lists
            else if (char.IsDigit(trimmedLine[0]) && trimmedLine.Length > 2 && trimmedLine[1..3].Contains('.'))
            {
                formatted.AppendLine($"  {trimmedLine}");
            }
            // Regular text with indentation
            else
            {
                formatted.AppendLine($"  {trimmedLine}");
            }
        }

        formatted.AppendLine();
        formatted.AppendLine("═══════════════════════════════════════════════════════════════");

        return formatted.ToString();
    }

}
