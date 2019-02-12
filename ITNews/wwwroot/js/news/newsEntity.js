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
            /*var news = {
                Content: $('#newsTextContent').val(),
                Name: newsEntity.newsModel.name,
                Description: newsEntity.newsModel.description,
                SectionId: 1,
                Tags: [{ Id: 1 }, { Id: 2 }]
            }*/
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
})