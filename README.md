# 爱奇艺爬虫
* 使用方法:
最简单的使用方法GET方式请求[http://movies.llili.cn/api/movies](http://movies.llili.cn/api/movies)
全部参数的列子GET方式请求[http://movies.llili.cn/api/movies?page=1&regin=1&type=11&guige=27815&year=2017](http://movies.llili.cn/api/movies?page=1&regin=1&type=11&guige=27815&year=2017)
* 参数
    *  page:页数 <br>如:page=1
    *  region:地区 <br>默认全部 1华语 28997香港 2美国 3欧洲 4韩国 308日本 1115泰国 5其它
    *  type:类型 <br>默认全部 8喜剧 13悲剧 6爱情 11动作 131枪战 291犯罪 128惊悚 10恐怖 289悬疑 12动画 27356家庭 1284奇幻<br>
    *  guige:规格 <br>默认全部 27397巨制 27815院线 30149独播 27401网络大电影 27976经典 27977口碑佳片 29696杜比 29698电影节目 297454K 296原声 311粤语<br>
    *  year:年代 <br>默认全部 2018 2017 2016 (year=2011_2015)2015-2011 2010-2000 90年代 80年代 (year=1964_1979)更早
