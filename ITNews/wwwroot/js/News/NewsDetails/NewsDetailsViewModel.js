let NewsDetailsViewModel = function (service) {
    let self = this;
    self._service = service;
    self.newsVue = new Vue({
        el: '#newsPartial',
        data: {
            news: new NewsModel(),
            tagsObject: [],
            tagsStringArray: [],
            selectedTags: [],
            sections: [],
            newComment: new Comment(),
            commentsHub: {}
        },
        methods: {
            initialize: function () {
                var newsId = getUrlParameter('id');
                if (newsId) {
                    self._service.getNewsDetails(newsId)
                        .done(function (data) {
                            let item = JSON.parse(data);
                            let comments = item.Comments.map(function (x) { return new Comment(x.Id, x.Content, x.CreatedDate, x.NewsId, x.AuthorId) });
                            self.newsVue.news = new NewsModel(item.Id, item.Author.Name, item.Name, item.Content, item.Description, item.Section.Id, item.Tags, item.AuthorId, comments, item.CreatedDate);
                            item.Tags.forEach(function (item) { self.newsVue.selectedTags.push(item.Name) });
                        });
                };
                this.commentsHub = new CommentsHub(this.addCommentToArr, this.updateCommentToArr, this.removeComment);
                self._service.getAllTags()
                    .done(function (data) {
                        let tags = JSON.parse(data);
                        self.newsVue.tagsObject = tags.map(function (item) { return new Tag(item.Id, item.Name) });
                        self.newsVue.tagsStringArray = tags.map(function (item) { return item.Name; });

                        autocomplete(document.getElementById("myInput"),
                            self.newsVue.tagsStringArray,
                            self.newsVue.selectedTags,
                            self.newsVue.autoCompleteCallBack);
                    });
                self._service.getAllSectionsOfNewsAction()
                    .done(function (data) {
                        let parsedSection = JSON.parse(data);
                        self.newsVue.sections = parsedSection.map(function (item) {
                            return new Section(item.Id, item.Name);
                        });
                    });
            },
            applyClick: function () {
                let news = self.newsVue.news;
                news.tags = [];
                self.newsVue.selectedTags.forEach(function (selectedTag) {
                    let isExist = false;
                    self.newsVue.tagsObject.forEach(function (tag) {
                        if (tag.name == selectedTag) {
                            news.tags.push(tag);
                            isExist = true;
                        }
                    });
                    if (!isExist) {
                        news.tags.push(new Tag(undefined, selectedTag))
                    }
                });
                
                self._service.saveNews(news)
                    .done(function (data) {
                        showSuccessAlert();
                    })
                    .fail(function (data) {

                    });
            },
            autoCompleteCallBack: function () {
                $('#myInput').val('');
            },
            removeTag: function (tag) {
                self.newsVue.selectedTags.forEach(function (item, index) {
                    if (item == tag) {
                        self.newsVue.selectedTags.splice(index, 1);
                    }
                })
            },
            createComment: function () {
                this.newComment.newsId = this.news.id;
                self._service.createComment(this.newComment)
                    .done(function (data) {
                        self.newsVue.newComment = new Comment();
                    });
            },
            addCommentToArr: function (comment) {
                if (comment.newsId == this.news.id) {
                    let com = new Comment(comment.id, comment.content, comment.createdDate, comment.newsId, comment.authorId);
                    this.news.comments.push(com);
                }
            },
            updateCommentToArr: function (comment) {
                if (comment.newsId == this.news.id) {
                    this.news.comments.push(comment);

                    this.news.comments.some(function (item, index) {
                        if (item.id == comment.id) {
                            Vue.set(this.news.comments, index, comment)
                            return true;
                        }
                        return false;
                    });
                }
            },
            removeComment: function (id) {
                let currentIndex;
                this.news.comments.some(function (item, index) {
                    if (item.id == id) {
                        currentIndex = index;
                        return true;
                    }
                    return false;
                });
                this.news.comments.splice(currentIndex, 1);
            }
        }
    });
}










/*
var newsEntity = new Vue({
    el: '#newsEntity',
    data: {
        newsModel: new NewsModel(1, '', '', '', '', 1, [{ Id: 1 }, { Id: 2 }]),
        markDown: {

        }
    },
    methods: {
        initialize: function () {
            var id = getUrlParameter('id')
            $.ajax({
                type: 'GET',
                url: domainPath + '/api/news/getnews?id=' + id,
                cache: false
            })
                .done(function (data) {
                    var parseData = JSON.parse(data);
                    var newObj = new NewsModel(parseData.Id, undefined, parseData.Name, parseData.Content, parseData.Description, parseData.Section, parseData.Tags);
                    newsEntity.newsModel = newObj;
                    newsEntity.$nextTick(function () {
                        newsEntity.markDown = $('#newsTextContent').markdownEditor({
                            preview: true,
                            onPreview: function (content, callback) {
                                callback(marked(content));
                            },
                            fullscreen: false,
                            preview: true,
                            height:'200px'
                        });

                        jQuery(newsEntity.markDown[0].nextSibling).find('div.btn-group.pull-right').hide()
                        
                        $(document).click(function (e) {
                            var div = $(".md-container");
                            if (!div.is(e.target)
                                && div.has(e.target).length === 0) {
                                event.stopPropagation();
                                markDownShowMode(newsEntity.markDown);
                            }
                        });
                        $('div.md-preview').click(function (event) {
                            editMode(newsEntity.markDown);
                            event.stopPropagation();
                        });
                        markDownShowMode(newsEntity.markDown);

                        ///name initialize
                        $('#newsName').click(function () {
                            $('#newsName').prop('readonly', '')
                        });
                        $(document).click(function (e) {
                            var div = $("#newsName");
                            if (!div.is(e.target)
                                && div.has(e.target).length === 0) {
                                event.stopPropagation();
                                $('#newsName').prop('readonly', 'readonly')
                            }
                        });

                        ///description inititalize
                        $('#newsDescription').click(function () {
                            $('#newsDescription').prop('readonly', '')
                        });
                        $(document).click(function (e) {
                            var div = $("#newsDescription");
                            if (!div.is(e.target)
                                && div.has(e.target).length === 0) {
                                event.stopPropagation();
                                $('#newsDescription').prop('readonly', 'readonly')
                            }
                        });
                    })

                })
                .fail(function () {

                });
        },
        editNews: function () {
            newsEntity.newsModel.content = $('#newsTextContent').val();
            $.ajax({
                type: 'POST',
                url: domainPath + '/api/news/EditNews',
                data: { news: newsEntity.newsModel },
                cache: false
            })
                .done(function (data) {
                    showSuccessAlert('');
                })
                .fail(function (data) {
                    showErrorAlert(data);
                });
        }
    }
})

$(document).ready(function () {
    newsEntity.initialize();
})*/