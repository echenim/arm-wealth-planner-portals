!function(r){"use strict";Berserk.behaviors.ranged_slider_init={attach:function(e,i){if(!(r("#slider").length<1)){if(void 0===r.fn.slider)return console.log("Waiting for the slider library"),void setTimeout(Berserk.behaviors.ranged_slider_init.attach,i.timeout_delay,e,i);r("#slider").slider({range:!0,min:1990,max:2018,step:1,values:[1996,2011],slide:function(e,i){for(var t=0;t<i.values.length;++t)r("input.sliderValue[data-index="+t+"]").val(i.values[t])}}),r("input.sliderValue").on("change",function(){var e=r(this);r("#slider").slider("values",e.data("index"),e.val())}),r("button#filter-trigger").on("click",function(){this.classList.toggle("closed"),this.nextElementSibling.classList.toggle("closed")}),r("button#categories-list-trigger").on("click",function(){var e=this.parentNode.parentNode;e.querySelector("#filter-trigger").classList.add("closed"),e.querySelector(".filter").classList.add("closed")})}}}}(jQuery);