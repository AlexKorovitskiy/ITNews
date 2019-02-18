let NewsViewModel = function (service) {
    let self = this;
    self._service = service;
    self.newsVue = new Vue({
        el: '#newsPage',
        data: {
            sections: [],
            activeSection: 0,
            userForFilter: 0,
            news: [],
            newsHub: {}
        },
        watch: {
            activeSection: function (newValue) {
                self.newsVue.fillNews(self.newsVue.userForFilter, newValue);
            }
        },
        methods: {
            initialize: function (userId) {
                self._service.getAllSectionsOfNewsAction()
                    .done(function (data) {
                        let sections = JSON.parse(data);
                        self.newsVue.sections = sections.map(function (item) {
                            return new Section(item.Id, item.Name);
                        });
                        self.newsVue.sections.unshift(new Section(0, 'All'));
                    });
                self.newsVue.fillNews(self.newsVue.userForFilter, self.activeSection)
                    .done(function () {
                        self.newsVue.$nextTick(function () {
                            $('.list-group-item.list-group-item-action').first().addClass('active');
                        })
                    });
                self.newsVue.newsHub = new NewsHub(this.addNews, this.updateNews, this.removeNews);
            },
            fillNews: function (userId, sectionId) {
                return self._service.getNews(userId, sectionId)
                    .done(function (data) {
                        let parsedData = JSON.parse(data);
                        self.newsVue.news = parsedData.news.map(function (item) {
                            return new NewsModel(item.Id, item.Author.Name, item.Name, item.Content, item.Description, item.SectionId, item.Tags, item.AuthorId);
                        });
                    });
            },
            sectionClick: function (sectionId) {
                self.newsVue.activeSection = sectionId;
            },
            hasEditPermissions: function (news) {
                if (IsAdmin()) {
                    return true;
                }

                if (isWriter() && news.authorId == getCurrentUserId()) {
                    return true;
                }

                return false;
            },
            hasAddNewsPermition: function () {
                if (IsAdmin() || isWriter()) {
                    return true;
                }
                return false;
            },
            addNews: function (news) {
                if (this.activeSection != 0 && this.activeSection != news.sectionId) {
                    return;
                }
                if (this.userForFilter != 0 && this.userForFilter != news.authorId) {
                    return;
                }
                this.news.unshift(news);
            },
            updateNews: function (news) {
                self.newsVue.news.some(function (item, index) {
                    if (item.id == news.id) {
                        Vue.set(self.newsVue.news, index, news)
                        return true;
                    }
                    return false;
                });
            },
            removeNews: function (id) {
                let currentIndex;
                self.newsVue.news.some(function (item, index) {
                    if (item.id == id) {
                        currentIndex = index;
                        return true;
                    }
                    return false;
                });
                self.newsVue.news.splice(currentIndex, 1);
            },
            userProfileUrl: function (userId) {
                return '/MySpace/PersanalData?id=' + userId;
            }
        }
    });
}