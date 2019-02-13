var UsersViewModel = function (service) {
    let self = this;
    self._service = service;
    self.usersVue = new Vue({
        el: '#adminUserListDiv',
        data: {
            users: [],
            userHub: {}
        },
        methods: {
            initialize: function () {
                self._service.getUsers()
                    .done(function (data) {
                        data.forEach(function (item) {
                            let user = new User(item.id, item.email, undefined, item.name, undefined, undefined);
                            self.usersVue.users.push(user);
                        });
                        self.usersVue.userHub = new UserHub(self.usersVue.addUserToLocal, self.usersVue.updateUserFromLocal, self.usersVue.removeUserFromLocal);
                    });
            },
            openUserProfileClick: function (user) {
                window.location.href = user.url;
            },
            deleteUserClick: function (user) {
                self._service.deleteUser(user.id)
                    .done(function () {
                        showSuccessAlert();
                    });
            },
            addUserToLocal: function (user) {
                self.usersVue.users.push(user);
            },
            updateUserFromLocal: function (user) {
                self.usersVue.users.some(function (item, index) {
                    if (item.id == user.id) {
                        Vue.set(self.usersVue.users, index, user)
                        return true;
                    }
                    return false;
                });
            },
            removeUserFromLocal: function (id) {
                let currentIndex;
                self.usersVue.users.some(function (item, index) {
                    if (item.id == id) {
                        currentIndex = index;
                        return true;
                    }
                    return false;
                });
                self.usersVue.users.splice(currentIndex, 1);
            }
        }
    });
}
