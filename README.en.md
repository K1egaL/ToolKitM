# ToolKitM

[Русская версия](README.md)

![Platform](https://img.shields.io/badge/platform-Windows-0078D4)
![.NET](https://img.shields.io/badge/.NET-10-512BD4)
![Language](https://img.shields.io/badge/language-C%23-239120)
![Status](https://img.shields.io/badge/status-development-orange)

**ToolKitM** is a small Windows command-line utility for PC and network diagnostics, system information, basic troubleshooting, and random value generation.

> **Project status:** Personal project. Features may change, break, or be removed in future versions.

## Features

- PC and network diagnostics
- Network adapter information
- DNS information and DNS resolution tests
- Active TCP connection viewer
- Ping test
- Full network connection check
- Random value generator
- Cryptographically secure random value generation
- Clipboard support
- System information
- CPU and RAM information
- Windows uptime
- Basic troubleshooting guides

## Requirements

- Windows
- .NET 10
- Visual Studio or another compatible .NET development environment

Some features use Windows-specific functionality and may not work on other operating systems.

## Usage

Run the application and select an option from the main menu:

```text
[1] PC Diagnostics
[2] Generator
[3] System Information
[4] Help & Troubleshooting

[0] Exit
```

## Warnings

> **WARNING:** ToolKitM is not an antivirus, firewall, VPN, security product, or full system repair tool.

> **WARNING:** Diagnostic results depend on the current Windows configuration, network state, permissions, drivers, and installed software.

> **WARNING:** Do not blindly execute commands shown in the troubleshooting sections. Make sure you understand what a command does before running it.

> **WARNING:** Some actions may affect network connectivity or Windows services. Use them carefully.

## Note

> **NOTE:** ToolKitM is provided as-is. There is no guarantee that every feature will work correctly on every Windows installation or hardware configuration.

## Project Structure

```text
ToolKitM/
├── Diagnostics/
├── Generator/
├── Help/
├── SystemInfo/
├── UI/
├── Program.cs
├── README.md
├── README.en.md
├── ToolKitM.csproj
└── ToolKitM.slnx
```

## Development

The project is written in **C#** and **.NET 10**.

The code is split into separate modules so that diagnostics, generation, system information, help, and UI components can be developed independently.

## Git

The project uses Git for version control.

Typical workflow:

```powershell
git add .
git commit -m "Describe your changes"
git push
```
