# InvoiceTool
此项目是基于WinForm的.NET Framwork应用程序
功能：处理PDF格式的发票文件并进行二维码信息的解析，一般它的右上角会有一个二维码，包含发票的关键信息，例如：票据代码、票据号码、校验码、开票日期、发票金额
实现：使用UglyToad.PdfPig库来读取 PDF 文件，使用 ZXing 库来解析二维码
