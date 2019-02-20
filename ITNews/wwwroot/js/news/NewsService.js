let NewsService = function (actions) {
    let self = this;
    self._actions = actions;

    self.getAllSectionsOfNewsAction = function () {
        return $.ajax({
            type: 'GET',
            url: self._actions.getAllSectionsOfNewsAction,
            cache: true
        });
    };

    self.getNews = function (userId, sectionId) {
        return $.ajax({
            type: 'GET',
            url: self._actions.getNewsAction,
            cache: false,
            data: {userId: userId, sectionId: sectionId}
        });
    };

    self.deleteNews = function (id) {
        return $.ajax({
            type: 'GET',
            url: self._actions.deleteNewsAction,
            cache: false,
            data: { id: id }
        });
    };
}