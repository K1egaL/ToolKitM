# ToolKitM

**ToolKitM** is a small Windows command-line utility for system
information, diagnostics, troubleshooting, and random value generation.

> **Project status:** Personal project. Features may change, break, or
> be removed at any time.

## Features

-   PC and network diagnostics
-   Network adapter information
-   DNS information and DNS resolution tests
-   Active TCP connection viewer
-   Ping test
-   Full network connection check
-   Random value generator
-   Cryptographically secure random value generation
-   Clipboard support
-   System information
-   CPU and RAM information
-   Windows uptime
-   Basic troubleshooting guides

## Requirements

-   Windows
-   .NET 10
-   Visual Studio or another compatible .NET development environment

Some features use Windows-specific functionality and may not work on
other operating systems.

## Usage

Run the application and select an option from the main menu.

``` text
[1] PC Diagnostics
[2] Generator
[3] System Information
[4] Help & Troubleshooting

[0] Exit
```

The application is designed to be simple and easy to use.

## Warnings

> **WARNING:** ToolKitM is not a security product, antivirus, firewall,
> VPN, or system repair tool.

> **WARNING:** Some diagnostic results depend on the current Windows
> configuration, network state, permissions, drivers, and installed
> software.

> **WARNING:** Do not blindly execute commands shown in troubleshooting
> sections. Make sure you understand what a command does before running
> it.

> **WARNING:** Some troubleshooting actions can affect network
> connectivity or Windows services. Use them carefully.

## Note

> **NOTE:** ToolKitM is provided as-is. No guarantee is made that every
> feature will work correctly on every Windows installation or hardware
> configuration.

## Project Structure

``` text
ToolKitM/
├── Diagnostics/
├── Generator/
├── Help/
├── SystemInfo/
├── UI/
├── Program.cs
├── ToolKitM.csproj
└── ToolKitM.slnx
```

## Development

The project uses C# and .NET 10.

The code is organized into separate modules so that diagnostics,
generation, system information, help, and UI components can be developed
independently.

## Git

The project uses Git for version control.

Typical workflow:

``` powershell
git add .
git commit -m "Describe your changes"
git push
```

## Русская версия

### О ToolKitM

**ToolKitM** --- небольшая консольная утилита для Windows,
предназначенная для получения информации о системе, диагностики ПК и
сети, устранения распространённых проблем и генерации случайных
значений.

> **Статус проекта:** Личный проект. Функции могут изменяться, ломаться
> или удаляться в следующих версиях.

### Возможности

-   Диагностика ПК и сети
-   Информация о сетевых адаптерах
-   Информация о DNS и проверка DNS-разрешения
-   Просмотр активных TCP-соединений
-   Проверка соединения через Ping
-   Полная проверка сетевого подключения
-   Генератор случайных значений
-   Криптографически безопасная генерация случайных значений
-   Копирование результата в буфер обмена
-   Информация о системе
-   Информация о CPU и RAM
-   Время работы Windows
-   Базовые инструкции по устранению неполадок

### Требования

-   Windows
-   .NET 10
-   Visual Studio или другая совместимая среда разработки для .NET

Некоторые функции используют возможности Windows и могут не работать в
других операционных системах.

### Предупреждения

> **ВНИМАНИЕ:** ToolKitM не является антивирусом, firewall, VPN,
> средством защиты или полноценным инструментом восстановления системы.

> **ВНИМАНИЕ:** Результаты диагностики зависят от текущих настроек
> Windows, состояния сети, разрешений, драйверов и установленного ПО.

> **ВНИМАНИЕ:** Не выполняйте команды из разделов troubleshooting
> вслепую. Перед запуском убедитесь, что вы понимаете назначение
> команды.

> **ВНИМАНИЕ:** Некоторые действия могут повлиять на сетевое подключение
> или службы Windows. Используйте их осторожно.

### Примечание

> **ПРИМЕЧАНИЕ:** ToolKitM предоставляется «как есть». Не гарантируется,
> что каждая функция будет корректно работать на любой установке Windows
> или любой конфигурации оборудования.

### Разработка

Проект написан на C# и .NET 10.

Код разделён на отдельные модули, чтобы диагностику, генератор,
информацию о системе, справку и UI можно было развивать независимо.

### Git

Для контроля версий используется Git.

Основной рабочий процесс:

``` powershell
git add .
git commit -m "Описание изменений"
git push
```
