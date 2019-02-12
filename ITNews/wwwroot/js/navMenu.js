var authorizeVue = new Vue({
    el: '#navMenu',
    data: {
        private_userIsAuthorize: '',
        email: sessionStorage.getItem('email')
    },
    computed: {
        userIsAuthorize:
        {
            get: function () {
                if (this.private_userIsAuthorize) {
                    return this.private_userIsAuthorize;
                }
                else {
                    var token = sessionStorage.getItem(tokenKey);
                    return token ? true : false;
                }
            },
            set: function (newValue) {
                this.private_userIsAuthorize = newValue;
            }
        }
        ,
        userIsNotAuthorize: function () {
            return !this.userIsAuthorize;
        }
    },
    methods: {
        logOut: function (event) {
            event.preventDefault();
            ITNewslogOut();
        }
    }
})
function ITNewslogIn(token, username) {
    username = username ? username : 'user';
    sessionStorage.setItem('email', username);
    sessionStorage.setItem(tokenKey, token);
    authorizeVue.userIsAuthorize = true;
}

function ITNewslogOut() {
    sessionStorage.removeItem(tokenKey);
    authorizeVue.userIsAuthorize = false;
    window.location.href = window.location.href;
}