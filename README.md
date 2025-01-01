# 滴滴发票归档插件

滴滴发票归档插件是一个基于 VSTO 的 Outlook 插件，可以帮助您自动整理滴滴行程发票。该插件使用 Visual Studio 2022 和 Visual Basic 开发。

## 功能

1. 检测包含滴滴行程单和发票附件的邮件。
2. 将附件下载到临时文件夹。
3. 使用百度 OCR API 识别 PDF 附件中的文字内容。
4. 根据 OCR 结果重命名附件。
5. 将处理后的文件移动到用户定义的目标文件夹。
6. 将处理完成的邮件标记为完成状态。
7. 清理临时文件夹。

## 系统要求

- Microsoft Outlook
- .NET Framework 4.7 或更高版本
- Microsoft Visual Studio Tools for Office Runtime
- 百度 OCR API 凭证（Client ID 和 Client Secret）

## 安装方法

1. 从 [Releases](https://github.com/C3604/DiDiInvoicePlugin/releases) 页面下载最新版本的 `.msi` 安装包。
2. 运行安装程序并按照提示完成安装。
3. 打开 Outlook，确保插件已在 **加载项** 标签中加载。

## 配置

1. 通过 Outlook 的 **加载项** 菜单进入插件设置。
2. 配置以下参数：
   - **目标文件夹**：设置处理后的文件存放路径。
   - **百度 OCR Client ID 和 Client Secret**：用于 OCR 功能的必需参数。

## 使用方法

1. 在 Outlook 中选择包含滴滴发票的邮件。
2. 点击加载项菜单中的 **归档** 按钮。
3. 插件将执行以下操作：
   - 检测并处理附件。
   - 使用 OCR 重命名文件。
   - 将文件移动到指定的目标文件夹。
   - 将邮件标记为已完成。

## 开发

### 开发环境要求

- Visual Studio 2022
- .NET Framework 4.7 或更高版本
- VSTO 开发环境

### 从源码构建

1. 克隆仓库：
   ```bash
   git clone https://github.com/C3604/DiDiInvoicePlugin.git
   ```
2. 在 Visual Studio 中打开解决方案。
3. 恢复 NuGet 包并确保已安装所有依赖项。
4. 构建项目并在 Outlook 中测试插件功能。

## 贡献

欢迎贡献代码！您可以提交问题或拉取请求来改进此项目。

## 许可证

本项目使用 MIT 许可证，详情请参阅 [LICENSE](LICENSE) 文件。

## 鸣谢

- 感谢 [百度 OCR API](https://ai.baidu.com/tech/ocr) 提供文字识别功能。
- 感谢开源社区的支持和工具。
