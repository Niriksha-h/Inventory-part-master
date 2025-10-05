
# Inventory Part Mastery — .NET 8 MVC + EF Core (SQLite)

**Schema**
- PartNumber: VARCHAR(50)
- PartName:   VARCHAR(100)
- PartLocation: VARCHAR(10)
- PartBin:    VARCHAR(5)
- StockQuantity: NUMBER (int)

## Prerequisites
- .NET SDK 8
- VS Code

## Run
```bash
dotnet restore
dotnet run
```
Open **http://localhost:5001**.

## Notes
- SQLite DB `inventory.db` created automatically with seed data.
- Dashboard (Home) shows totals + **Chart.js** bar chart that updates after CRUD changes.
- Manage parts at **/Parts** (Create, Edit, Delete, Details).
