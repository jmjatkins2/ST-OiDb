app.controller('loginController', function ($scope, auth, $location, store) {

    this.login = function () {
        auth.signin({
            disableSignupAction: true,
            disableResetAction: true,
            gravatar: false,
            authParams: { scope: 'openid name given_name email role' }
        }, function (profile, token) {
            //alter scope if you want more profile properties, or can change to scope: 'openid profile' if you 
            //want them all, but that is a lot of data
            store.set('profile', profile);
            store.set('token', token);
            $location.path('/');
        }, function (error) {
            console.log("There was an error logging in", error);
        });
    }

    if (!auth.isAuthenticated)
        this.login();
});