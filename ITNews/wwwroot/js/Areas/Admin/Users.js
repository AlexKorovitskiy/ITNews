var UsersViewModel = function (service) {
    let self = this;
    self._service = service;
    self.usersVue = new Vue({
        el: '#adminUserListDiv',
        data: {
            users: []
        },
        methods: {
            initialize: function () {
                self._service.getUsers()
                    .done(function (data) {
                        data.forEach(function (item) {
                            let user = new User(item.id, item.email, undefined, item.name, undefined, undefined);
                            self.usersVue.users.push(user);
                        });
                    });
            }
        }
    });
}
