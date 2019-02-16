let NewsService = function (actions) {
    let self = this;
    self._actions = actions;
    self.getAllTags = function () {
        return $.ajax({
            type: 'GET',
            url: self._actions.getAllTagsAction,
            cache: true
        });
    };

    self.getAllSectionsOfNewsAction = function () {
        return $.ajax({
            type: 'GET',
            url: self._actions.getAllSectionsOfNewsAction,
            cache: true
        });
    };
    
    self.createNews = function (news) {
        return $.ajax({
            type: 'POST',
            url: self._actions.createNewsAction,
            data: { news: news }
        });
    };
}