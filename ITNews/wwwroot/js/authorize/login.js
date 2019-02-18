let LoginViewModel = function (service) {
    let self = this;
    self.service = service;
    self.loginVue = new Vue({
        el: '#loginform',
        data: {
            user: new User()
        },
        methods: {
            logIn: function (event) {
                event.preventDefault();
                self.loginVue.user.grant_type = 'password';
                self.service.logIn(self.loginVue.user)
                    .done(function (data) {
                        ITNewslogIn(data.token.access_token, data.user);
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

$(document).ready(function () {
    $('#inputEmail').focus()
})