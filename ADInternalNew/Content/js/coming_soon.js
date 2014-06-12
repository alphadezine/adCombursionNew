$(function(){

	/*  Initiation of Countdown (time in timestamp)  */
	$('.countdown').final_countdown({
      'start': 1362139200,
      'end': 1394662920,
      'now': 1387461319        
  });

	/*  Background slide  */
	if($('body').attr('data-page') == 'coming-soon'){
		$.backstretch([
			"Content/img/background/05.png",
			"Content/img/background/04.png", 
			"Content/img/background/06.png",
		  "Content/img/background/07.png", 
		  "Content/img/background/08.png"], 
		  {
		    fade: 3000,
		    duration: 0 
		});
	}

});


