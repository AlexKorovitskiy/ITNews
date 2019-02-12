var Loader = function (data) {
    let self = this;
    self.data = data;
    self.getActions = function () {
        return $.ajax({
            type: 'GET',
            url: data.getActionsUrl,
            cache: false
        });
    }
}