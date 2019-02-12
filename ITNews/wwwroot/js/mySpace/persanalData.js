let PesanalDataViewModel = function (service) {
    let self = this;
    self._service = service;
    self.persanalDataVue = new Vue({
        el: '#persanaldataContainer',
        data: {
            user: new User()
        },
        methods: {
            initialize: function () {
                self._service.getCurrentUser()
                    .done(function (data) {
                        let user = JSON.parse(data);
                        self.persanalDataVue.user = new User(user.Id, user.Email, user.Password, user.Name, user.Photo);
                    })
                    .fail(function (user) {
                        showErrorAlert(data);
                    });
            },
            saveUser: function () {
                self._service.updateUser(self.persanalDataVue.user)
                    .done(function () {
                        showSuccessAlert();
                    })
                    .fail(function () {
                        showErrorAlert(data);
                    });
            }
        }
    });
};