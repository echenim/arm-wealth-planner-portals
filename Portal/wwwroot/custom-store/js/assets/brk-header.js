!function(x){"use strict";Berserk.behaviors.header_init={attach:function(e,n){x(e).parent().find(".brk-header:not(.rendered)").addClass("rendered").each(function(){var c=x(this),r=c.find(".brk-header__main-bar"),a=r.data("height-scroll"),n=992,o=c.data("sticky-hide");x("body").width();if(x(".brk-header__top-bar").length){var t=c.find(".brk-header__top-bar_hide"),s=c.find(".brk-header__top-bar_scroll"),l=c.find(".brk-header__top-bar").data("top");l=l||0;var e=function(e){if(e<=(window.innerWidth||x(window).width())){if(t.length){var n=t.innerHeight()-l;if(x("body").hasClass("admin-bar")){var i=n-32;c.css("top","-"+i+"px")}else c.css("top","-"+n+"px")}}else c.css("top","0")},i=function(e){if(1!==o)if(e<=(window.innerWidth||x(window).width())){if(s.length){var n=s.innerHeight()-l;if(0<x(window).scrollTop())if(x("body").hasClass("admin-bar")){var i=n-32;c.css("top","-"+i+"px")}else c.css("top","-"+n+"px");else x(window).scrollTop()<=0&&(x("body").hasClass("admin-bar")?c.css("top","32px"):c.css("top","0"))}}else c.css("top","0")};setTimeout(function(){e(n)},2e3),i(n),x(window).on("resize scroll",function(){e(n),i(n)})}if(x(".brk-open-top-bar").length){var d=c.find(".brk-open-top-bar");d.on("click",function(){d.toggleClass("active"),c.toggleClass("top-bar-active")})}function b(e){var n=window.innerWidth||x(window).width();if(a)var i=r.data("height-temp");c.hasClass("brk-header_not-fixed")||e<=n&&(0<x(window).scrollTop()?(c.addClass("brk-header_scroll"),a&&r.css("height",a+"px")):x(window).scrollTop()<=0&&(c.removeClass("brk-header_scroll"),a&&r.css("height",i+"px"))),0<x(window).scrollTop()?x(".brk-header-mobile").addClass("brk-header-mobile_scroll"):x(window).scrollTop()<=0&&x(".brk-header-mobile").removeClass("brk-header-mobile_scroll")}if(a&&r.data("height-temp",r.height()),b(n),x(window).on("scroll",function(){b(n)}),1===o){var h=0;setTimeout(function(){x(window).on("scroll",function(){var e=x(this).scrollTop(),n=!1,i=!1;0<e&&(h<e?(n=!1,e<c.height()+c.offset().top&&!1===i&&(c.addClass("brk-header_sticky-hide"),i=!0)):(i=!1,e>c.offset().top&&!1===n&&(c.removeClass("brk-header_sticky-hide"),n=!0)),h=e)})},2500)}var v=!1;function k(e){var n=window.innerWidth||x(window).width();if(n<e&&!v){c.wrap('<div class="brk-header-mobile-wrap"><div class="brk-header-mobile-wrap__body"></div></div>');var i=x(".brk-header-mobile-wrap"),r=x(".brk-header-mobile-wrap__body"),a=c.data("logo-src"),o=c.data("bg-mobile");r.prepend('<div class="brk-before"></div><div class="brk-header-mobile-wrap__header"><div class="brk-header-mobile-wrap__close"><span></span></div></div>'),""!==a&&x(".brk-header-mobile-wrap__header").prepend('<div class="brk-header-mobile-wrap__logo"><img src="'+a+'" alt=""></div>'),""!==o&&void 0!==o&&i.css("background-image","url("+o+")"),i.before('<div class="brk-header-mobile-wrap-layer"></div>'),v=!0}else e<=n&&v&&(x(".brk-header-mobile-wrap__header").detach(),x(".brk-header-mobile-wrap-layer").remove(),x(".brk-before, .brk-header-mobile-wrap__header").remove(),c.unwrap(),c.unwrap(),v=!1);var t=x(".brk-header-mobile"),s=t.find(".brk-header-mobile__open"),l=(i=x(".brk-header-mobile-wrap")).find(".brk-header-mobile-wrap__close"),d=x(".brk-header-mobile-wrap-layer");t.length&&s.on("click",function(){x("body").addClass("modal-open"),i.addClass("is-active"),d.addClass("is-active")}),i.length&&l.on("click",function(){x("body").removeClass("modal-open"),i.removeClass("is-active"),d.removeClass("is-active")})}k(n),x(window).on("resize",function(){k(n)});var f=!1;function p(e){var n=x(".brk-nav, .brk-header-popup-menu"),i=n.find(".brk-nav__children"),r=n.find(".brk-nav__menu > li").children("a"),a=n.find("a"),o=window.innerWidth||x(window).width();if(o<e&&!f){if(i.prepend('<div class="brk-nav__link-open"><i class="fa fa-angle-right"></i></div>'),x(".brk-nav__link-open").length){var t=x(".brk-nav__link-open");0<t.length&&t.on("click",function(){var e=x(this),n=e.parent(),i=n.children(".brk-nav-drop-down");n.toggleClass("children-active"),e.toggleClass("is-active"),i.slideToggle(400)}),r.each(function(){var e=x(this),n=e.attr("href");"/"!==n&&("#"===n[0]&&1===n.length||"javascript:void(0)"===n||!n.length)&&e.on("click",function(e){e.preventDefault();var n=x(this).parent(),i=n.children(".brk-nav-drop-down"),r=n.children(".brk-nav__link-open");n.toggleClass("children-active"),r.toggleClass("is-active"),i.slideToggle(400)})})}a.each(function(){var e=x(this),i=e.attr("href");"#"===i[0]&&e.on("click",function(e){if(e.preventDefault(),x(i).length){var n=x(this).parents(".brk-header-mobile-wrap");x("body").removeClass("modal-open"),n.removeClass("is-active"),x(".brk-header-mobile-wrap-layer").removeClass("is-active")}})}),f=!0}else 0<x(".brk-nav__link-open").length&&e<=o&&f&&(x(".brk-nav__link-open").remove(),i.removeClass("children-active"),f=!1)}x(window).on("load",function(){p(n)}),x(window).on("resize",function(){p(n)}),x(".brk-nav__drop-down-effect").each(function(){var e=x(this),a=e.find(".dd-effect");e.on("mouseenter",function(){var e,n,i,r;e=a,n=10,r="left"===i?{opacity:0,left:10}:{opacity:0,left:-10},(e="left"===i?x(e.get().reverse()):e).css(r).each(function(e){x(this).delay(n*e).animate({opacity:1,left:0})})})}),x(".brk-quantity").find(".brk-quantity__arrows").on("click",function(){var e=x(this).parent().find(".brk-quantity__value"),n=e.val();x(this).hasClass("minus")&&1<n?e.val(+n-1):x(this).hasClass("plus")&&e.val(+n+1)});var u,_=x(".brk-info-menu"),m=x(".brk-info-menu-open"),w=_.find(".brk-info-menu__close"),g=window.innerWidth||x(window).width();function C(e,n,i,r){n=(e=x(e)).find(n),i=e.find(i);var a=window.innerWidth||x(window).width();a<r?n.unbind("click").on("click",function(){i.slideToggle(400)}):r<=a&&(n.unbind("click"),i.css("display",""))}function y(e){var n=window.innerWidth||x(window).width();n<e?x(".brk-lang:not(.brk-lang-rendered)").addClass("brk-lang-rendered").each(function(){var e=x(this),n=e.find(".brk-lang__open"),i=e.find(".brk-lang__option");e.unbind(),n.on("click",function(){i.slideToggle(300)})}).removeClass("brk-lang_interactive-rendered"):e<=n&&(x(".brk-lang_interactive:not(.brk-lang_interactive-rendered)").addClass("brk-lang_interactive-rendered").each(function(){var e=x(this),n=e.closest(".brk-header__top-bar, .brk-header__main-bar"),i=n.find(".container-fluid, .container"),r=n.find(".brk-header__item:not(.brk-lang_interactive)"),a=r.parents('[class*="col"]');n.css({height:n.outerHeight(),transition:"height .3s"}),e.on({mouseenter:function(){r.css("opacity","0"),i.css("background","transparent !important"),n.addClass("top-bar-bg"),x("div").is(".brk-overlay")||c.after('<div class="brk-overlay"></div>'),a.css("border","0")},mouseleave:function(){r.css("opacity","1"),i.removeAttr("style"),n.removeClass("top-bar-bg"),x("div").is(".brk-overlay")&&x(".brk-overlay").remove(),a.css("border","")}})}).removeClass("brk-lang-rendered"),x(".brk-lang__option").css("display",""),x(".brk-lang").find(".brk-lang__open").unbind("click"))}function T(){var i=window.innerWidth||x(window).width();if(!(i<992)){x(".brk-mini-cart, .brk-social-links, .brk-search, .brk-lang, .brk-nav__sub-menu, .flexMenu-popup").each(function(){var e=x(this),n=i/2+350;e.offset().left+e.width()/2<n?e.removeClass("brk-location-screen-left brk-location-screen-right").addClass("brk-location-screen-left"):e.removeClass("brk-location-screen-left brk-location-screen-right").addClass("brk-location-screen-right")})}}m.on("click",function(){_.toggleClass("active"),m.toggleClass("open-active"),n<=g&&x("body").toggleClass("modal-open")}),w.on("click",function(){_.hasClass("active")&&_.removeClass("active"),m.hasClass("open-active")&&m.removeClass("open-active"),n<=g&&x("body").hasClass("modal-open")&&x("body").removeClass("modal-open")}),x(document).on("click",function(e){x(e.target).closest(".brk-info-menu").length||x(e.target).closest(".brk-info-menu-open").length||(_.hasClass("active")&&_.removeClass("active"),m.hasClass("open-active")&&m.removeClass("open-active"),n<=g&&x("body").hasClass("modal-open")&&x("body").removeClass("modal-open")),e.stopPropagation()}),C(".brk-mini-cart",".brk-mini-cart__open, .brk-mini-cart__info-open",".brk-mini-cart__menu",n),C(".brk-social-links",".brk-social-links__open",".brk-social-links__block",n),C(".brk-search",".brk-search__open",".brk-search__block",n),x(window).on("resize",function(){C(".brk-mini-cart",".brk-mini-cart__open, .brk-mini-cart__info-open",".brk-mini-cart__menu",n),C(".brk-social-links",".brk-social-links__open",".brk-social-links__block",n),C(".brk-search",".brk-search__open",".brk-search__block",n)}),u=window.innerWidth||x(window).width(),n<=u&&x(".brk-search_interactive").each(function(){var e=x(this),n=e.parents(".brk-header__main-bar"),i=n.children(".container-fluid, .container"),r=e.find(".brk-search__open"),a=e.find(".brk-search__close"),o=e.find(".brk-search__block"),t=o.find('[type="search"]'),s=n.find(".brk-header__item:not(.brk-search_interactive)"),l=s.parents('[class*="col"]');r.on("click",function(){o.addClass("active"),i.addClass("position-relative"),s.hide(0),x(this).hide(0),x("div").is(".brk-overlay")||c.after('<div class="brk-overlay"></div>'),setTimeout(function(){t.focus()},150),l.css("border","0")}),a.on("click",function(){o.removeClass("active"),s.show(0),r.show(0),i.removeClass("position-relative"),x("div").is(".brk-overlay")&&x(".brk-overlay").remove(),l.css("border","")}),x(document).on("click",function(e){x(e.target).closest(".brk-header").length||(o.removeClass("active"),s.show(0),r.show(0),i.removeClass("position-relative"),x("div").is(".brk-overlay")&&x(".brk-overlay").remove(),l.css("border","")),e.stopPropagation()})}),window.addEventListener("load",function(){y(n)}),x(window).on("resize",function(){y(n)}),function(){if(0<x(".brk-header-popup-menu").length){c.after('<div class="brk-header-popup-menu-layer"></div>');var n=x(".brk-header-popup-menu").find(".brk-header-popup-menu__open-close"),i=x(".brk-header-popup-menu__menu"),r=x(".brk-header-popup-menu-layer"),a=i.find("a");0<x(".brk-header_vertical").length&&(x(".brk-header").append(i),i.addClass("brk-moved-by-js")),n.on("click",function(){x(this).toggleClass("is-active"),i.fadeToggle(300),r.fadeToggle(500)}),r.on("click",function(){var e=x(this);n.toggleClass("is-active"),i.fadeToggle(300),e.fadeToggle(500)}),a.each(function(){var e=x(this).attr("href");"#"===e[0]&&1<e.length&&x(e).length&&a.on("click",function(){n.removeClass("is-active"),i.fadeOut(300),r.fadeOut(500)})})}}(),x(".brk-totop").on("click",function(){x("html, body").stop().animate({scrollTop:0},500)}),x(window).on("load",function(){setTimeout(function(){T()},300)}),T(),x(window).on("resize",function(){T()})})}},Berserk.behaviors.header_init_menu_flex={attach:function(e,n){if(!(x(".brk-nav:not(.rendered)").length<1)){if("function"!=typeof x.fn.flexMenu)return console.log("Waiting for the flexMenu library"),void setTimeout(Berserk.behaviors.header_init_menu_flex.attach,n.timeout_delay,e,n);var r=!0;x(e).parent().find(".brk-nav:not(.rendered)").addClass("rendered").each(function(){var e=x(this),n=e.find(".brk-nav__menu"),i=e.data("flexmenu-link-text");0===e.closest(".brk-header_vertical").length&&(i=i||"More",window.addEventListener("load",function(){a(n,i)}),x(window).on("resize",function(){a(n,i)}))})}function a(n,e){var i=window.innerWidth||x(window).width();i<992&&!r?(n.flexMenu({undo:!0}),r=!0):992<=i&&r&&(n.flexMenu({linkText:e}),setTimeout(function(){if(x(".flexMenu-viewMore").length){var e=x(".flexMenu-popup").offset().left+80;n.find(".flexMenu-viewMore .brk-nav__mega-menu").attr("style","width: calc(100vw - "+e+"px)")}},500),r=!1)}}}}(jQuery);