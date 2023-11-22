mergeInto(LibraryManager.library,
{
	AuthorizationCheck: function (playerPhotoSize, scopes)
	{
		AuthorizationCheck(Pointer_stringify(playerPhotoSize), scopes);
	},
	
	OpenAuthDialog: function (playerPhotoSize, scopes)
	{
		OpenAuthDialog(Pointer_stringify(playerPhotoSize), scopes);
	},
	
	SaveYG: function (jsonData, flush)
	{
		SaveCloud(Pointer_stringify(jsonData), flush);
	},
	
	LoadYG: function ()
	{
		LoadCloud();
	},
	
	InitLeaderboard: function ()
	{
		InitLeaderboard();
	},
	
	SetLeaderboardScores: function (nameLB, score)
	{
		SetLeaderboardScores(Pointer_stringify(nameLB), score);
	},
	
	GetLeaderboardScores: function (nameLB, maxPlayers, quantityTop, quantityAround, photoSizeLB, auth)
	{
		GetLeaderboardScores(Pointer_stringify(nameLB), maxPlayers, quantityTop, quantityAround, Pointer_stringify(photoSizeLB), auth);
	},

	FullAdShow: function ()
	{
		FullscreenShow();
	},

    RewardedShow: function (id)
	{
		RewardedShow(id);
	},
	
	LanguageRequest: function ()
	{
		LanguageRequest();
	},
	
	RequestingEnvironmentData: function()
	{
		RequestingEnvironmentData();
	},	

	Review: function()
	{
		Review();
	},
	
	ActivityRTB1: function(state)
	{
		ActivityRTB1(state);
	},
	
	ActivityRTB2: function(state)
	{
		ActivityRTB2(state);
	},
	
	ActivityRTB3: function(state)
	{
		ActivityRTB3(state);
	},
	
	ActivityRTB4: function(state)
	{
		ActivityRTB4(state);
	},
	
	RecalculateRTB1: function(_width, _height, _left, _right, _top, _bottom, _offset)
	{
		RecalculateRTB1(
			Pointer_stringify(_width),
			Pointer_stringify(_height),
			Pointer_stringify(_left),
			Pointer_stringify(_right),
			Pointer_stringify(_top),
			Pointer_stringify(_bottom),
			Pointer_stringify(_offset));
	},
	
	RecalculateRTB2: function(_width, _height, _left, _right, _top, _bottom, _offset)
	{
		RecalculateRTB2(
			Pointer_stringify(_width),
			Pointer_stringify(_height),
			Pointer_stringify(_left),
			Pointer_stringify(_right),
			Pointer_stringify(_top),
			Pointer_stringify(_bottom),
			Pointer_stringify(_offset));
	},
	
	RecalculateRTB3: function(_width, _height, _left, _right, _top, _bottom, _offset)
	{
		RecalculateRTB3(
			Pointer_stringify(_width),
			Pointer_stringify(_height),
			Pointer_stringify(_left),
			Pointer_stringify(_right),
			Pointer_stringify(_top),
			Pointer_stringify(_bottom),
			Pointer_stringify(_offset));
	},
	
	RecalculateRTB4: function(_width, _height, _left, _right, _top, _bottom, _offset)
	{
		RecalculateRTB4(
			Pointer_stringify(_width),
			Pointer_stringify(_height),
			Pointer_stringify(_left),
			Pointer_stringify(_right),
			Pointer_stringify(_top),
			Pointer_stringify(_bottom),
			Pointer_stringify(_offset));
	},
	
	GetURLFromPage: function () {
        var returnStr = (window.location != window.parent.location) ? document.referrer : document.location.href;
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
		
        return buffer;
    }
});