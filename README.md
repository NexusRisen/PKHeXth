<p align="center">
  <img src="https://github.com/user-attachments/assets/9b116801-8935-4441-9bfe-d76192f84857" alt="PKHeXth Banner" width="600"/>
</p>

<h1 align="center">PKHeXth</h1>

<p align="center">
  <strong>Enhanced Pokémon Save File Editor with Pre-installed Plugins</strong>
</p>

<p align="center">
  <a href="https://github.com/NexusRisen/PKHeXth/releases/latest"><img src="https://img.shields.io/github/v/release/NexusRisen/PKHeXth?style=for-the-badge&color=blue" alt="Latest Release"/></a>
  <a href="https://github.com/NexusRisen/PKHeXth/releases"><img src="https://img.shields.io/github/downloads/NexusRisen/PKHeXth/total?style=for-the-badge&color=green" alt="Total Downloads"/></a>
  <img src="https://img.shields.io/badge/License-GPLv3-blue?style=for-the-badge" alt="License"/>
</p>

<p align="center">
  <a href="#features">Features</a> •
  <a href="#pre-installed-plugins">Plugins</a> •
  <a href="#download">Download</a> •
  <a href="#building">Building</a> •
  <a href="#supported-formats">Formats</a>
</p>

---

<div>
  <span>English</span> / <a href=".github/README-es.md">Español</a> / <a href=".github/README-fr.md">Français</a> / <a href=".github/README-de.md">Deutsch</a> / <a href=".github/README-it.md">Italiano</a> / <a href=".github/README-ko.md">한국어</a> / <a href=".github/README-zh-Hant.md">繁體中文</a> / <a href=".github/README-zh-Hans.md">简体中文</a>
</div>

---

## What is PKHeXth?

PKHeXth is an enhanced fork of [PKHeX](https://github.com/kwsch/PKHeX) that comes **batteries-included** with popular plugins pre-installed and ready to use. No more hunting down plugins, dealing with compatibility issues, or manual setup — just download and go.

This project combines the power of PKHeX with essential community plugins for a complete Pokémon save editing experience.

## Features

- **All-in-One Package** — Everything you need in a single download
- **Auto Legality Mod (ALM)** — Generate legal Pokémon from Showdown sets instantly
- **Live Injection** — Connect directly to your console via SysBot for real-time editing
- **Seed Finders** — Find RNG seeds for Sword/Shield, Scarlet/Violet, and Legends: Arceus
- **Living Dex Builder** — Build and track your Living Dex completion
- **PluginPile Suite** — Fashion editing, raid importing, sorting, and more
- **Regular Updates** — Stays current with upstream PKHeX changes
- **Code Signed** — Releases are signed for security

## Pre-installed Plugins

| Plugin | Description |
|--------|-------------|
| **Auto Legality Mod** | Generate legal Pokémon from Showdown paste/sets with one click |
| **PKHeX.Core.Injection** | Live connection to Switch consoles via SysBot |
| **SV Seed Finder** | Find and manipulate seeds in Scarlet/Violet |
| **SWSH Seed Finder** | Find and manipulate seeds in Sword/Shield |
| **PLZA Seed Finder** | Seed tools for Pokémon Legends: Arceus |
| **Fashion Editor** | Edit trainer clothing and accessories |
| **Raid Importer** | Import raid data directly |
| **Roamer Tool** | Track and edit roaming Pokémon |
| **Sorting Plugin** | Advanced box sorting options |
| **Special Pokémon Finder** | Find special encounters and events |
| **SwSh Rules Exporter** | Export battle rules from Sword/Shield |
| **Living Dex Builder** | Build and track your Living Dex completion |

## Download

Get the latest release from the [Releases Page](https://github.com/NexusRisen/PKHeXth/releases/latest).

### Requirements
- Windows 10/11 (64-bit)
- [.NET 9.0 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/9.0) (or use the self-contained build)

## Supported Formats

| Type | Extensions |
|------|------------|
| **Save Files** | `main`, `.sav`, `.dsv`, `.dat`, `.gci`, `.bin` |
| **Memory Cards** | `.raw`, `.bin` (GameCube) |
| **Pokémon Files** | `.pk*`, `.ck3`, `.xk3`, `.pb7`, `.sk2`, `.bk4`, `.rk4` |
| **Mystery Gifts** | `.pgt`, `.pcd`, `.pgf`, `.wc*` |
| **GO Park** | `.gp1` |
| **Battle Videos** | Decrypted 3DS battle videos |

Additional capabilities:
- Import/Export Showdown sets and QR codes
- Convert between generations
- Full Mystery Gift database included

## Screenshots

![Main Window](https://i.imgur.com/pIHdoTp.png)

## Building

PKHeXth requires [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) and supports C# 13.

```bash
# Clone the repository
git clone https://github.com/NexusRisen/PKHeXth.git

# Build
dotnet build PKHeX.sln -c Release
```

Open `PKHeX.sln` in [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) or your preferred IDE.

## Save Management

PKHeX expects **decrypted** save files (not encrypted with console-specific keys). Use a save manager to export saves from your console:

- [Checkpoint](https://github.com/FlagBrew/Checkpoint) (3DS/Switch)
- [JKSM](https://github.com/J-D-K/JKSM) (3DS)
- SaveDataFiler

## Dependencies & Credits

- [PKHeX](https://github.com/kwsch/PKHeX) by Kaphotics — The original save editor
- [PKHeX-Plugins](https://github.com/architdate/PKHeX-Plugins) — Auto Legality Mod
- [PluginPile](https://github.com/foPokemon/PluginPile) — Plugin suite
- [QRCoder](https://github.com/codebude/QRCoder) — QR code generation (MIT License)
- [pokesprite](https://github.com/msikma/pokesprite) — Shiny sprite collection (MIT License)
- [National Pokédex Icon Dex](https://www.deviantart.com/pikafan2000/art/National-Pokedex-Version-Delta-Icon-Dex-824897934) — Legends: Arceus sprites

## Disclaimer

**We do not support or condone cheating at the expense of others.** Do not use significantly hacked Pokémon in battles or trades with those who are unaware that hacked Pokémon are in use.

---

<p align="center">
  <sub>Made with care for the Pokémon community</sub>
</p>
