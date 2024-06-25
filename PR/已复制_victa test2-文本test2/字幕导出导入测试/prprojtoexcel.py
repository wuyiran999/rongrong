import pandas as pd

# 定义项目文件路径
file_path = r'G:\视频剪辑job\已复制_victa test\victa test2.prproj'

# 逐行读取文件内容
texts = []
with open(file_path, 'rb') as file:
    for line in file:
        try:
            decoded_line = line.decode('utf-8').strip()
        except UnicodeDecodeError:
            try:
                decoded_line = line.decode('latin-1').strip()
            except UnicodeDecodeError:
                continue
        if "Hold down the Shift key" in decoded_line or "Align Select Object" in decoded_line:
            texts.append(decoded_line)

# 检查提取的文本是否为空
if not texts:
    print("No texts found in the .prproj file.")
else:
    # 将文本框内容写入 Excel 文件
    df = pd.DataFrame(texts, columns=["Text"])
    excel_path = r'G:\视频剪辑job\已复制_victa test\exported_texts.xlsx'
    df.to_excel(excel_path, index=False)
    print(f"文本框内容已导出到 {excel_path}")
