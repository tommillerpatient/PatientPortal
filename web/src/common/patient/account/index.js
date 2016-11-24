import angular from 'angular';


const patientKey = "patient_info";
const tokenKey = "access_token";

function auth() {
    return !!localStorage.getItem(tokenKey);
}

function getPatient() {
    var patientJson = localStorage.getItem(patientKey);
    if(patientJson){
        return JSON.parse(patientJson);
    }
    return null;
}

function setPatient(patient) {
    if(patient){
        localStorage.setItem(patientKey, JSON.stringify(patient));
    }else {
        localStorage.removeItem(patientKey);
    }

}

function getToken() {
    return localStorage.getItem(tokenKey);
}

function setToken(token) {
    if(token){
        localStorage.setItem(tokenKey, token);
    }else {
        localStorage.removeItem(tokenKey);
    }

}


angular.module('account', [])
    .service('AccountService', ['$http', function ($http) {


    $http.defaults.useXDomain = true;
    $http.defaults.headers.common = { 'Access-Control-Allow-Origin': '*' };
    delete $http.defaults.headers.common["X-Requested-With"];


    function signOut() {
        setToken(null);
        setPatient(null);
    }

    function signIn(email, password, cb) {
        var req = {
            method: 'POST',
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json",
            }
        };

        req.url = SERVICE_URL + '/api/account/sign-in?email=' + encodeURIComponent(email) + '&password=' + encodeURIComponent(password);

        $http(req).then(function (res) {

            setToken(res.data.token);
            setPatient(res.data.patient);
            cb(res.data.error);

        }).catch(function (e) {
            cb(e);
        });
    }

    function reset(email, password, newPassword, cb) {
        var req = {
            method: 'POST',
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json",
            }
        };

        req.url = SERVICE_URL + '/api/account/reset?email=' + encodeURIComponent(email) + '&password=' + encodeURIComponent(password) + '&newPassword=' + encodeURIComponent(newPassword);

        $http(req).then(function (res) {

            cb(res.data.error);

        }).catch(function (e) {
            cb(e);
        });
    }

    function addPatient(patient, cb) {
        var req = {
            method: 'POST',
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            data: patient
        };

        req.url = '/api/patient/add';

        $http(req).then(function (res) {

            cb(res.data);

        }).catch(function (e) {
            cb(e);
        });
    }

    function updatePatient(patient, cb) {
        var req = {
            method: 'POST',
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            data: patient
        };

        req.url = SERVICE_URL + '/api/patient/update?token=' + getToken();

        $http(req).then(function (res) {

            cb(res.data.error);

        }).catch(function (e) {
            cb(e);
        });
    }

    return {
        auth: auth,
        getPatient: getPatient,
        signOut: signOut,
        signIn: signIn,
        reset: reset,
        addPatient: addPatient,
        updatePatient: updatePatient
    }
}]);

module.exports = 'account';