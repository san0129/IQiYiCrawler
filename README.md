# 爱奇艺爬虫
## 使用方法:
 * 最简单的使用方法GET方式请求[http://movies.llili.cn/api/movies](http://movies.llili.cn/api/movies)
 * 全部参数的例子GET方式请求[http://movies.llili.cn/api/movies?page=1&regin=1&type=11&guige=27815&year=2017](http://movies.llili.cn/api/movies?page=1&regin=1&type=11&guige=27815&year=2017)
     
## 项目简介:
 * .net core webapi的练手项目 服务器采用Debian9
 * 前端是朋友用vue写的，[项目链接](https://github.com/fengle0224/web_tv)
 * 项目链接[http://movies.llili.cn/]（http://movies.llili.cn/）
* 参数
 * page:页数 <br>如:page=1
 * region:地区 <br>默认全部 1华语 28997香港 2美国 3欧洲 4韩国 308日本 1115泰国 5其它
 * type:类型 <br>默认全部 8喜剧 13悲剧 6爱情 11动作 131枪战 291犯罪 128惊悚 10恐怖 289悬疑 12动画 27356家庭 1284奇幻
 * guige:规格 <br>默认全部 27397巨制 27815院线 27976经典 27977口碑佳片 9698电影节目 29745 4K 296原声 311粤语
 * year:年代 <br>默认全部 2018 2017 2016 (year=2011_2015)2015-2011 2010-2000 90年代 80年代 (year=1964_1979)更早
