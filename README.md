# WebApi2Db
一個專案連到兩個資料庫的範例
```
選擇MDB1Repository專案執行
Add-Migration Test1  -Args '–environment Local' -Context 'MDB1Context'
Script-Migration  -Args '–environment Local' -Context 'MDB1Context'
Script-Migration -From Demo1 -To Demo2 -Args '–environment Local' -Context 'MDB1Context'
remove-migration -Args '–environment Local' -Context 'MDB1Context'

選擇MDB2Repository專案執行
Add-Migration Test2  -Args '–environment Local' -Context 'MDB12Context'

```
