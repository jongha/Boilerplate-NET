# CoffeeScript

## AngularJS Application
API_MEMBERLIST = '/api/Members'
API_TIMEZONE = '/api/TimeZone'

boilerplateApp = angular.module('boilerplateApp', []);

boilerplateApp.controller('membersListCtrl', ['$scope', '$http', ($scope, $http) ->
    $http.get(API_MEMBERLIST)
        .success((data, status, headers, config) -> 
            $scope.members = data
        )
        .error((data, status, headers, config) -> console.log data)
        
    return
])

boilerplateApp.controller('homeIndexCtrl', ['$scope', '$http', ($scope, $http) ->

    $scope.countries = [ 'Korea', 'Japan', 'United States of America']
    $scope.countrySelected = { name: $scope.countries[0].name };
                
    $scope.selectCountry = () ->
        getTimeZones($scope.country)
        return
    
    getTimeZones = (country) ->
        $http.get(API_TIMEZONE + '?country=' + country)
            .success((data, status, headers, config) -> 
                $scope.timeZones = data
                $scope.timeZone = data[0].StandardName;
            )
            .error((data, status, headers, config) -> console.log data)
    
    getTimeZones()
    
    return
])

## jQuery Application
$(document).ready(() ->
    memberList = $('#memberList')
    
    if memberList and memberList.length
        $.ajax({
          url: API_MEMBERLIST
          success: (data, textStatus, jqXHR ) -> 
            (
                tr = $('<tr></tr>')
                tr.append($('<td></td>').html(datum.Id))
                tr.append($('<td></td>').html(datum.Email))
                tr.append($('<td></td>').html(datum.Name))
                tr.append($('<td></td>').html(datum.CreateDate))
            
                memberList.append tr
            
            ) for datum in data
        
            return
          dataType: 'json'
        });
    return
)