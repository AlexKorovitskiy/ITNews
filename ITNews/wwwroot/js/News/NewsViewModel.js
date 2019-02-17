let NewsViewModel = function (service) {
    let self = this;
    self._service = service;
    self.newsVue = new Vue({
        el: '#newsPage',
        data: {
            sections: [],
            activeSection: {},
            news: []
        },
        watch: {
            activeSection: function (newValue) {
                self.newsVue.fillNews(0, newValue);
            }
        },
        methods: {
            initialize: function () {
                self._service.getAllSectionsOfNewsAction()
                    .done(function (data) {
                        let sections = JSON.parse(data);
                        self.newsVue.sections = sections.map(function (item) {
                            return new Section(item.Id, item.Name);
                        });
                        self.newsVue.sections.unshift(new Section(0, 'All'));
                    });
                self.newsVue.fillNews();
            },
            fillNews: function (userId, sectionId) {
                self._service.getNews(userId, sectionId)
                    .done(function (data) {
                        let parsedData = JSON.parse(data);
                        self.newsVue.news = parsedData.news.map(function (item) {
                            return new NewsModel(item.Id, item.Author.Name, item.Name, item.Content, item.Description, item.SectionId, item.Tags);
                        });
                    });
            },
            sectionClick: function (sectionId) {
                self.newsVue.activeSection = sectionId;
            }
        }
    });
}