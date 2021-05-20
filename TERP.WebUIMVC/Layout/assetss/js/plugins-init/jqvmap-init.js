(function($) {
    /* "use strict" */


 var dzVectorMap = function(){
	
	var screenWidth = $(window).width();
	
	var handleWorldMap = function(trigger = 'load'){
		var vmapSelector = $('#world-map');
		if(trigger == 'resize')
		{
			vmapSelector.empty();
			vmapSelector.removeAttr('style');
		}
		
		vmapSelector.delay( 500 ).unbind().vectorMap({ 
			map: 'world_en',
			backgroundColor: 'transparent',
			borderColor: 'rgb(239, 242, 244)',
			borderOpacity: 0.25,
			borderWidth: 1,
			// color: 'rgb(239, 242, 244)',
			color: 'rgb(101,103,115)',
			enableZoom: true,
			// hoverColor: 'rgba(239, 242, 244 0.9)',
			hoverColor: 'rgba(59, 50, 137, 0.9)',
			hoverOpacity: null,
			normalizeFunction: 'linear',
			scaleColors: ['#b6d6ff', '#005ace'],
			// selectedColor: 'rgba(239, 242, 244 0.9)',
			selectedColor: 'rgba(239,127,27,0.9)',
			selectedRegions: null,
			showTooltip: true,
			onRegionClick: function(element, code, region)
			{
				var message = 'Ülke:'
					+ region
					+ ', Uluslararası Kodu: '
					+ code.toUpperCase();
		 
				// alert(message);
				document.getElementById("region-name").innerHTML=message;
			}
		});
	}
	
	// var handleUsaMap = function(trigger = 'load'){
	// 	var vmapSelector = $('#usa');
	// 	if(trigger == 'resize')
	// 	{
	// 		vmapSelector.empty();
	// 		vmapSelector.removeAttr('style');
	// 	}
		
	// 	vmapSelector.delay(500).unbind().vectorMap({ 
	// 		map: 'usa_en',
	// 		backgroundColor: 'transparent',
	// 		borderColor: 'rgb(239, 242, 244)',
	// 		borderOpacity: 0.25,
	// 		borderWidth: 1,
	// 		color: 'rgb(239, 242, 244)',
	// 		enableZoom: true,
	// 		hoverColor: 'rgba(239, 242, 244 0.9)',
	// 		hoverOpacity: null,
	// 		normalizeFunction: 'linear',
	// 		scaleColors: ['#b6d6ff', '#005ace'],
	// 		selectedColor: 'rgba(239, 242, 244 0.9)',
	// 		selectedRegions: null,
	// 		showTooltip: true,
	// 		onRegionClick: function(element, code, region)
	// 		{
	// 			var message = 'You clicked "'
	// 				+ region
	// 				+ '" which has the code: '
	// 				+ code.toUpperCase();
		 
	// 			alert(message);
	// 		}
	// 	});
	// }
	
		return {
			init:function(){
			},
			
			
			load:function(){
				handleWorldMap();
				// handleUsaMap();
			},
			
			resize:function(){
				handleWorldMap('resize');
				// handleUsaMap('resize');
			}
		}
	
	}();

	jQuery(document).ready(function(){
	});
		
	jQuery(window).on('load',function(){
		setTimeout(function(){
			dzVectorMap.load();
		}, 1000); 
		
	});

	jQuery(window).on('resize',function(){
		setTimeout(function(){
			dzVectorMap.resize();
		}, 1000); 
		
	});     

})(jQuery);	