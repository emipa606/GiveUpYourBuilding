# GitHub Copilot Instructions for RimWorld Modding - Give Up Your Building (Continued)

Welcome to the modding project repository for the RimWorld mod "Give Up Your Building (Continued)". As a mod developer or contributor, this guide will help you understand the purpose of the mod, key features, coding patterns, XML integration, and how to utilize harmony patching effectively. Additionally, we provide suggestions on how to leverage GitHub Copilot to enhance your development process.

## Mod Overview and Purpose

- **Mod Name**: Give Up Your Building (Continued)
- **Author**: LingLuo
- **Display Name**: Give up your building (Continued)
- **Description**: This mod is an update of LingLuo's original mod, allowing players to relinquish ownership of their buildings so that enemies won't target them during raids. Unlike similar mods, this mod ensures buildings no longer belong to anyone, offering a strategic advantage especially against insect invasions.

## Key Features and Systems

- **Unclaim Structures**: Allows players to designate structures that should not be targeted by enemies by relinquishing ownership.
- **Strategic Differentiation**: Provides a clear advantage in specific scenarios, such as facing insect threats, by making buildings unowned instead of re-owned by enemies.
- **Language Support**: Available in Simplified Chinese and English to cater to a wider audience.

## Coding Patterns and Conventions

- **File Structure**: 
  - C# code is stored in the `Source` directory, under `GiveUpYourBuilding`.
  - XML files for patches and definitions are stored in the `Patches` and `DefInjected` directories, respectively.

- **C# Conventions**:
  - Follow standard C# coding conventions, such as PascalCase for class names and camelCase for method names.
  - Ensure clarity in method naming to reflect their purpose, e.g., `CanDesignateCell` and `DesignateSingleCell`.
  - Use `Designator` pattern for implementing interfaces related to selectable game objects, like `Designator_GiveUpBuilding`.

## XML Integration

- **Patch.xml**: Contains Harmony patches, ensuring compatibility and integration with the RimWorld architecture.
- **About.xml**: Provides metadata about the mod, such as name, author, and description, needed by the RimWorld mod manager.
- **DesignationCategoryDef**: XML file defining new designations for relinquishing building ownership.
- **KeyBindingCategoryDef**: Adds architect menu category for the mod through XML configurations.

## Harmony Patching

- **Purpose**: Harmony is used for method modifications to ensure seamless integration of new features with existing game mechanics.
- **Patch Structure**: Ensure all patches are logically organized in `Patch.xml` and comply with Harmony guidelines.
- **Version Control**: Regularly update and maintain patches to align with mod updates and the latest version of RimWorld.

## Suggestions for Copilot

- **Utilizing Copilot for C# Code**:
  - Enable auto-completion and suggestions when writing or refactoring existing methods in classes such as `Designator_GiveUpBuilding`.
  - Ask Copilot for code snippets or refactoring suggestions to enhance performance or readability.

- **XML Configuration with Copilot**:
  - Use Copilot to draft new XML nodes for additional designations or key bindings.
  - Validate suggested XML snippets against the game’s schema to ensure proper loading and integration.

## Reporting Issues and Contributing

- **Issue Tracking**: Log errors using the Log Uploader and report them in the dedicated Discord channel.
- **Contribution**: Share solutions to identified problems within the GitHub repository to assist with collaborative fixing and improvements.
- **Mod Sorting**: Utilize RimSort to manage the order and compatibility of active mods.

This document serves as your main guide for developing and contributing to the "Give Up Your Building (Continued)" mod. Adhering to outlined conventions will ensure a smooth and efficient development process. Happy modding!

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

