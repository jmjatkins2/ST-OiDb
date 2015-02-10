app.controller('homeController', function ($scope, auth) {

    $scope.auth = auth;

    if (auth.isAuthenticated) {
        if (auth.profile.given_name != null)
            $scope.message = "Hi " + auth.profile.given_name + "!";
        else
            $scope.message = "Signed in as " + auth.profile.name + "!";
    }
    else
        $scope.message = "Welcome!"
});