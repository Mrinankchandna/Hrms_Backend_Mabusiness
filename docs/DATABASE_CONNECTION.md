# Visual Studio Database Connection Guide

## Connect to Supabase PostgreSQL in Visual Studio

### Step 1: Install PostgreSQL Provider
1. Open Visual Studio
2. Go to **Tools** → **Extensions and Updates**
3. Search for "PostgreSQL" or "Npgsql"
4. Install **Npgsql PostgreSQL Integration**
5. Restart Visual Studio

### Step 2: Open Server Explorer
1. Go to **View** → **Server Explorer**
2. Right-click on **Data Connections**
3. Select **Add Connection...**

### Step 3: Configure Connection
**Connection Properties:**
- **Data Source**: PostgreSQL Database (Npgsql)
- **Server**: aws-1-ap-southeast-2.pooler.supabase.com
- **Port**: 5432
- **Database**: postgres
- **User ID**: postgres.ctnvhvatcqxatwlzfyal
- **Password**: [YOUR_SUPABASE_PASSWORD]
- **SSL Mode**: Require
- **Trust Server Certificate**: True

### Step 4: Test Connection
1. Click **Test Connection**
2. Should show "Test connection succeeded"
3. Click **OK** to save

### Step 5: View Tables
1. Expand your connection in Server Explorer
2. Expand **Tables** folder
3. You can now:
   - View table structure
   - Browse data
   - Run queries
   - Create/modify tables

### Connection String Format:
```
Host=aws-1-ap-southeast-2.pooler.supabase.com;Database=postgres;Username=postgres.ctnvhvatcqxatwlzfyal;Password=YOUR_PASSWORD;Port=5432;SSL Mode=Require;Trust Server Certificate=true
```

### Alternative: SQL Server Management Studio (SSMS)
If Visual Studio doesn't work, you can use:
- **pgAdmin** (PostgreSQL native tool)
- **Azure Data Studio** (supports PostgreSQL)
- **DBeaver** (universal database tool)

### Troubleshooting:
- Ensure Npgsql provider is installed
- Check firewall settings
- Verify Supabase password is correct
- Use direct connection port (5432) not pooled (6543)