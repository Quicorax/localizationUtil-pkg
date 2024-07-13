# Localization Utility Package
--- by @quicorax ---

Google sheets AppScript code:

```function exportLocalization() {
  var sheet = SpreadsheetApp.getActiveSpreadsheet().getActiveSheet();
  var data = sheet.getDataRange().getValues();
  var headers = data[0];
  var translations = [];

  for (var i = 1; i < data.length; i++) {
    var key = data[i][0];
    if (!key) 
    {
      continue;
    }
    var localizedBundle = [];
    for (var j = 1; j < headers.length; j++) {
      if (headers[j].startsWith('_')) 
      {
        continue;
      }
      localizedBundle.push({
        LanguageKey: headers[j],
        Text: data[i][j]
      });
    }
    translations.push({
      TextKey: key,
      LocalizedBundle: localizedBundle
    });
  }

  Logger.log(JSON.stringify({ data: translations }));
  return JSON.stringify({ data: translations }, null, 2);
}

function doGet(r)
{
  return ContentService.createTextOutput(exportLocalization());
}
```

Sample Google Sheets model format:
![image](https://github.com/user-attachments/assets/cd459690-0b1a-40e9-9a1e-3e585050152e)

