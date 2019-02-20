let NewsDetailsService = function (actions) {
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

    self.saveNews = function (news) {
        return $.ajax({
            type: 'POST',
            url: news.id && news.id > 0 ? self._actions.editNewsAction : self._actions.createNewsAction,
            data: { news: news }
        });
    };

    self.getNewsDetails = function (id) {
        return $.ajax({
            type: 'GET',
            url: self._actions.getNewsDetailsAction,
            data: { id: id }
        });
    };
    
    self.createComment = function (comment) {
        return $.ajax({
            type: 'POST',
            url: self._actions.createCommentAction,
            data: { comment: comment }
        });
    }; 
}