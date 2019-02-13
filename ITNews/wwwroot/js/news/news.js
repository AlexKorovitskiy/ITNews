var newsVue = new Vue({
    el: '#newsBlock',
    data: {
        news:[]
    },
    methods: {
        initialize: function () {
            $.ajax({
                type: 'GET',
                url: domainPath + '/api/news/getAllNews',
                cache: false
            })
                .done(function (data) {

                })
                .fail(function (data) {

                });
        }
    }
})

$(document).ready(function () {
    newsVue.initialize();
})