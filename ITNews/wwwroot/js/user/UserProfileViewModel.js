let UserProfileViewModel = function (service) {
    let self = this;
    self._service = service;
    self.persanalDataVue = new Vue({
        el: '#persanaldataContainer',
        data: {
            user: new User(),
            roles: []
        },
        methods: {
            initialize: function () {
                self._service.getRoles()
                    .done(function (data) {
                        let roles = JSON.parse(data);
                        roles.forEach(function (item) {
                            let role = new Role(item.Id, item.Name);
                            self.persanalDataVue.roles.push(role);
                        });
                    })
                //self._service.getCurrentUser()
                var id = getUrlParameter('id');
                self._service.getUser(id)
                    .done(function (data) {
                        let user = JSON.parse(data);
                        let roles = user.Roles.map(function (item) {
                            return new Role(item.Id, item.Name);
                        })
                        self.persanalDataVue.user = new User(user.Id, user.Email, user.Password, user.Name, user.Photo, roles);
                    })
                    .fail(function (data) {
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