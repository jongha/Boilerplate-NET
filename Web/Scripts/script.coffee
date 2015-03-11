# CoffeeScript

## AngularJS Application
API_MEMBERLIST = '/api/Members'
API_TIMEZONE = '/api/TimeZone'

boilerplateApp = angular.module('boilerplateApp', [])

boilerplateApp.filter('format', () ->
  return (input, args) ->
    input = input || ''
    
    for i in [0..args.length - 1]
        exp = new RegExp('\\{' + i + '\\}', 'gi')
        input = input.replace(exp, args[i])
        
    return input;
);

boilerplateApp.controller('membersListCtrl', ['$scope', '$http', ($scope, $http) ->
    $http.get(API_MEMBERLIST)
        .success((data, status, headers, config) -> 
            $scope.members = data
        )
        .error((data, status, headers, config) -> console.log data)
        
    return
])

boilerplateApp.controller('homeIndexCtrl', ['$scope', '$http', ($scope, $http) ->

    getLocalTime = (utcOffset) ->
        now = new Date();
        tick = 0
        if matches = utcOffset.match(/([+-]?\d{2,2}):(\d{2,2}):(\d{2,2})$/)
           tick = ((parseInt(matches[1]) * 60 * 60) + (parseInt(matches[2]) * 60) + parseInt(matches[3])) * 1000
        
        utc = now.getTime() + (now.getTimezoneOffset() * 60 * 1000);
        return new Date(utc + tick);
    
    $scope.selectLanguage = () ->
        location.href = './?lang=' + $scope.language + '&tz=' + $scope.timeZone.Id
        return
        
    $scope.selectTimeZone = () ->
        currentDate = getLocalTime($scope.timeZone.BaseUtcOffset)
        hour = currentDate.getHours() 
        minute = currentDate.getMinutes()
        
        $scope.hour = if hour < 10 then '0' + hour else hour
        $scope.minute = if minute < 10 then '0' + minute else minute
        return
            
    $http.get(API_TIMEZONE)
        .success((data, status, headers, config) -> 
            $scope.timeZones = data
            
            if !!!$scope.timeZoneParam
                $scope.timeZone = data[0];
            else
                for i in [0..data.length - 1]
                    if $scope.timeZoneParam == data[i].Id
                        $scope.timeZone = data[i];
                        break

            $scope.selectTimeZone()
            return
        )
        .error((data, status, headers, config) -> console.log data)
        
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