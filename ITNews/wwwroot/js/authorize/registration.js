let RegistrationViewModel = function (service) {
    let self = this;
    self.service = service;
    self.registrationVue = new Vue({
        el: '#registrationForm',
        data: {
            user: new User()
        },
        methods: {
            registration: function () {
                self.registrationVue.user.grant_type = 'password';
                self.service.registration(self.registrationVue.user)
                    .done(function (data) {
                        ITNewslogIn(data.token.access_token, data.user.Email);
                        window.location.href = frontPath;
                    })
                    .fail(function (data) {
                        console.log(data);
                        showErrorAlert('Fail')
                });
            }
        }
    });
}