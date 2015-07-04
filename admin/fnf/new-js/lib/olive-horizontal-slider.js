/*
 * jQuery Olive Slider v1.3
 * http://oliveglobal.com/
 *
 * Copyright 2012 Olive E-business Pvt. Ltd.
 * Free to use under the GPLv2 license.
 * http://www.gnu.org/licenses/gpl-2.0.html
 *
 * Contributing author: Hemraj (SSE)
 * Dependency : JQuery 1.6+
 * Last updated : 07-apr-2014
 * Options : 
	- duration : time of animation
	- cur_position : panel position from which you want to start slider
	- previousButtonId : button id to be used as previous button
	- nextButtonId : button id to be used as next button
	- easingEffect : easing effect for animation
	- oneByOne : specify if all visible panel to be moved or one by one panel to be moved
	- visiblePanels : specify numbers of panel to be visible in slider
	- panelHeight : if slider is not visible at initialization, you can provide the height of each panel or 'li' yourself
 */


(function($){
    $.fn.extend({
    	oliveVerticalSlider: function(options) {
            var defaults = { duration: 1500, cur_position:0,previousButtonId:"preBtn",nextButtonId:"nextBtn",easingEffect:"swing",oneByOne:false,visiblePanels:3,panelHeight:0};
            var options = $.extend(defaults, options);
            var silderContainer=this;
            var preBtn=$("#"+options.previousButtonId);
            var nextBtn=$("#"+options.nextButtonId);
            var belt=silderContainer.children("div");
            var panels=belt.children().children();
            var beltHeight=0;
            var silderContainerHeight=silderContainer.height();
            var scrollAmount=silderContainerHeight;
            var panel = $("li",$(this));
            if (options.panelHeight != 0) {
                panel.css("height", options.panelHeight + "px");
            }
            panels.each(function(){
                beltHeight = beltHeight + panel.outerHeight(true);
            });

            if(options.visiblePanels>0){
            	scrollAmount=panel.outerHeight(true)*options.visiblePanels;
            	silderContainerHeight=scrollAmount;
            	silderContainer.css("height",300+"px");
            }
            if(options.oneByOne)
            	scrollAmount=panel.outerHeight(true);
            belt.css("height",beltHeight+"px");
            options.cur_position=panel.outerHeight(true)*options.cur_position;
            belt.css("top","-"+options.cur_position+"px");
            $(preBtn).click(function(){
			   
            	var newMovementSize = scrollAmount;
        		if (options.cur_position <scrollAmount) {
        			newMovementSize = options.cur_position;
					
        		}
				//stops if it is last panel
        		if(options.cur_position==0){$(this).addClass("ended");return;}
				
				 
            	options.cur_position=options.cur_position-newMovementSize;
            	$(belt).stop().animate({
    				top : "-"+options.cur_position+"px"
    			}, 
	    			options.duration,options.easingEffect,
					function() {
						
					}
            	);
				
				//Dissable button end reached
				 $(".ended").removeClass("ended");
				
				if (options.cur_position<=0) {
					$(this).addClass("ended");
			    } 
            });
            $(nextBtn).click(function(){
				
            	var newMovementSize = scrollAmount;
            	var remainingBeltBlock = (beltHeight - ((parseInt(options.cur_position) + scrollAmount)));
            	if(options.oneByOne){
            		remainingBeltBlock = (beltHeight - ((parseInt(options.cur_position) + silderContainerHeight)));
            	    //remainingBeltBlock+=scrollAmount;
            	}
        		if (remainingBeltBlock < scrollAmount) {
        			newMovementSize = remainingBeltBlock;
					
        		}
        		//stops if it is last panel
				if(newMovementSize<=0){	$(this).addClass("ended");return;	}
				
				
            	options.cur_position=options.cur_position+newMovementSize;
            	$(belt).stop().animate({
    				top : "-"+options.cur_position+"px"
    			}, 
	    			options.duration,options.easingEffect,
					function() {
						
					}
            	);
				//Dissable button end reached
				$(".ended").removeClass("ended");
				var nextMove=(beltHeight - ((parseInt(options.cur_position) + silderContainerHeight)));
				if (nextMove<=0) {
					$(this).addClass("ended");
			    } 
            });
            return this;
        }
    });
})(jQuery);