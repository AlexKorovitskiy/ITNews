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
function ITNewslogIn(token, user) {
    sessionStorage.setItem('email', user.Email ? user.Email : 'user');
    sessionStorage.setItem('currentUserId', user.Id);
    debugger;
    let hasAdminRole = user.Roles.some(function (item) { return item.Name == 'admin'; })
    sessionStorage.setItem('isAdmin', hasAdminRole);
    let hasWriterRole = user.Roles.some(function (item) { return item.Name == 'writer'; })
    sessionStorage.setItem('isWriter', hasWriterRole);
    sessionStorage.setItem(tokenKey, token);
    authorizeVue.userIsAuthorize = true;
}

function ITNewslogOut() {
    sessionStorage.removeItem(tokenKey);
    authorizeVue.userIsAuthorize = false;
    window.location.href = window.location.href;
}

function IsAdmin() {
    return sessionStorage.getItem('isAdmin') == 'true';
}

function isWriter() {
    return sessionStorage.getItem('isWriter') == 'true';
}

function getCurrentUserId() {
    return sessionStorage.getItem('currentUserId');
}