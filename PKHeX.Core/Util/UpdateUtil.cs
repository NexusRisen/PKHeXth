using System;

namespace PKHeX.Core;

public static class UpdateUtil
{
    /// <summary>
    /// Gets the latest version of PKHeX according to the GitHub API
    /// </summary>
    /// <returns>A version representing the latest available version of PKHeX, or null if the latest version could not be determined</returns>
    public static Version? GetLatestPKHeXVersion()
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

        var tagString = responseJson.AsSpan()[first..second];
        return !Version.TryParse(tagString, out var latestVersion) ? null : latestVersion;
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

        // Find the browser_download_url for PKHeX.exe
        const string assetName = "\"name\":\"PKHeX.exe\"";
        var assetIndex = responseJson.IndexOf(assetName, StringComparison.Ordinal);
        if (assetIndex == -1)
            return null;

        const string urlTag = "\"browser_download_url\":\"";
        var urlIndex = responseJson.IndexOf(urlTag, assetIndex, StringComparison.Ordinal);
        if (urlIndex == -1)
            return null;

        var first = urlIndex + urlTag.Length;
        var second = responseJson.IndexOf('"', first);
        if (second == -1)
            return null;

        return responseJson[first..second];
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

        // Find the body field which contains the changelog
        const string bodyTag = "\"body\":\"";
        var bodyIndex = responseJson.IndexOf(bodyTag, StringComparison.Ordinal);
        if (bodyIndex == -1)
            return null;

        var first = bodyIndex + bodyTag.Length;
        var second = responseJson.IndexOf("\",\"", first, StringComparison.Ordinal);
        if (second == -1)
            return null;

        var changelog = responseJson[first..second];
        // Unescape JSON string
        changelog = changelog.Replace("\\n", "\n")
                             .Replace("\\r", "\r")
                             .Replace("\\t", "\t")
                             .Replace("\\\"", "\"")
                             .Replace("\\/", "/")
                             .Replace("\\\\", "\\");

        return changelog;
    }
}
