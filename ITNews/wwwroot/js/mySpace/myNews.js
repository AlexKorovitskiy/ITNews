let MyNewsViewModel = function (service) {
    let self = this;
    self._service = service;
    self.myNewsBlock = new Vue({
        el: '#myNewsBlock',
        data: {
            news: [],
            newNews: new NewsModel(),
            markdownsArray: [],
            newsHub: {}
        },
        methods: {
            initialize: function () {
                self._service.getMyNews()
                    .done(function (data) {
                        var parseData = JSON.parse(data);
                        parseData.forEach(function (item) {
                            var newObj = new NewsModel(item.Id, item.Author.Name, item.Name, item.Content, item.Description, item.Section, item.Tags, item.AuthorId);
                            self.myNewsBlock.news.push(newObj);
                        })
                        self.myNewsBlock.$nextTick(function () {
                            self.myNewsBlock.news.forEach(function (item) {
                                var key = item.id;
                                var value = $('#newsTextContent_' + item.id).markdownEditor({
                                    preview: true,
                                    onPreview: function (content, callback) {
                                        callback(marked(content));
                                    },
                                    fullscreen: false,
                                    preview: true
                                });
                                self.myNewsBlock.markdownsArray.push({ key: key, value: value })
                            })
                        });
                        self.myNewsBlock.newsHub = new NewsHub(self.myNewsBlock.pushNewsToMainArray,
                            self.myNewsBlock.updateNewsFromMainArray,
                            self.myNewsBlock.deleteNewsFromMainArray)
                    })
                    .fail(function (data) {
                    });
            },
            addNewsButtonClick: function () {
                $('#createNewsArea').toggle();
            },
            addNews: function () {
                self.myNewsBlock.newNews.content = $('#createNewsTextArea').val();
                self.myNewsBlock.newNews.sectionId = 1;
                self._service.addNewsForCurrentUser(self.myNewsBlock.newNews)
                    .done(function (data) {
                        self.myNewsBlock.newsHub.addNews(myNewsBlock.newNews);
                        self.myNewsBlock.newNews = new NewsModel();
                        showSuccessAlert();
                        self.myNewsBlock.addNewsButtonClick();
                    })
                    .fail(function (data) {
                        showErrorAlert(data);
                    });
            },
            pushNewsToMainArray: function (news) {
                self.myNewsBlock.news.push(news);
            },
            updateNewsFromMainArray: function (news) {
                self.myNewsBlock.news.some(function (item, index) {
                    if (item.id == news.id) {
                        Vue.set(self.myNewsBlock.news, index, news)
                    }
                    return false;
                });
            },
            deleteNewsFromMainArray: function (id) {
                let currentIndex;
                self.myNewsBlock.news.some(function (item, index) {
                    if (item.id == id) {
                        currentIndex = index;
                        return true;
                    }
                    return false;
                });
                self.myNewsBlock.news.splice(currentIndex, 1);
            },
            deleteNews: function (id) {
                self._service.deleteNews(id)
                    .done(function (data) {
                        showSuccessAlert();
                    })
                    .fail(function (data) {
                        showErrorAlert(data);
                    });
            }
        }
    })
}


$(document).ready(function () {
    //MyNewsViewModel.myNewsBlock.initialize();

    

    /*document.getElementById("chatInputButton").addEventListener("click", function (e) {
        var message = $("#cahtInput").val();
        if (message && groupId) {
            hubConnectionMyNews.invoke("AddNews", message, groupId);
            $("#cahtInput").val("");
        }
    });*/


})

