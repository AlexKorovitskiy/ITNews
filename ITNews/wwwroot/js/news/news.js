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
                    debugger;
                })
                .fail(function (data) {
                    debugger
                });
        }
    }
})

$(document).ready(function () {
    newsVue.initialize();
})