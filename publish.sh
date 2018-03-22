cd IQiYiCrawler
service kestrel-iqiyi stop
git pull
dotnet publish
systemctl start kestrel-iqiyi
systemctl status kestrel-iqiyi