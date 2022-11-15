# Oveerview

This is the Apex project used to provide frontend training accelerator for Sitefinity frontend development & integration documented on [https://americaneagle.atlassian.net/wiki/spaces/KNOW/pages/150463502354433/Sitefinity+Frontend+Development+Workshop](https://americaneagle.atlassian.net/wiki/spaces/KNOW/pages/150463502354433/Sitefinity+Frontend+Development+Workshop)

# Solution Structure

* **Apex.Web** - The Sitefinity Web Application
* **db** folder - A folder to commit DB bacpac

# Setup Instructions

It is best to host the project in IIS. Follow this guide to set the project in IIS [https://www.progress.com/documentation/sitefinity-cms/run-projects-on-iis](https://www.progress.com/documentation/sitefinity-cms/run-projects-on-iis)

## DB Restore

1. The DB is located in the `db` folder of the root of the project - `\db\apex_db.bacpac`
1. Restore the `.bacpac` file using the [https://americaneagle.atlassian.net/wiki/spaces/KNOW/pages/263783238/Restore+db+from+.bacpac](https://americaneagle.atlassian.net/wiki/spaces/KNOW/pages/263783238/Restore+db+from+.bacpac) link
1. Locate the `DataConfig.config` is located in `\Apex.Web\App_Data\Sitefinity\Configuration\DataConfig.config`
1. Modify the connection string located in `DataConfig.config` to match to the DB server, catalog name, and authentication properties needed to connect your solution

```xml
<add connectionString="data source=BG-1WS107\MSSQL2017;Integrated Security=SSPI;initial catalog=apex_db" name="Sitefinity" />
```

