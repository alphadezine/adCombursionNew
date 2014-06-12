$(function(){

	if($('body').attr('data-page') == 'login' || $('body').attr('data-page') == 'signup' || $('body').attr('data-page') == 'password'){
		
		/*  For icon rotation on input box foxus  */ 	
		$('.input-field').focus(function() {
				$('.page-icon img').addClass('rotate-icon');
		});

		/*  For icon rotation on input box blur  */ 	
		$('.input-field').blur(function() {
				$('.page-icon img').removeClass('rotate-icon');
		});
	};

	/*  Background slide for lockscreen page  */
	if($('body').attr('data-page') == 'lockscreen'){
		$.backstretch([ "Content/img/background/01.png", "Content/img/background/02.png", "Content/img/background/03.png", "Content/img/background/04.png", "Content/img/background/05.png", "Content/img/background/06.png",
		  "Content/img/background/07.png", "Content/img/background/08.png", "Content/img/background/09.png" ], 
		  {
		    fade: 600,
		    duration: 4000 
		});
	}

	/*  Background slide for lockscreen page  */
	if($('body').attr('data-page') == 'login' || $('body').attr('data-page') == 'signup'){
		$('#submit-form').click(function(e){
        e.preventDefault();
        var l = Ladda.create(this);
        l.start();
        setTimeout(function () {
            window.location.href = "index.html";
        }, 2000);

    });
	}

});


