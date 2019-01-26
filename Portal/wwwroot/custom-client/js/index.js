;
(function($, window, document, undefined) {


    "use strict";

//        if ($('.datepicker')) {
//$('.datepicker').datepicker({
//    format: 'mm/dd/yyyy'
//});
//}



// page load efect

    $('a[href]:not([target="_blank"]):not([href^="#"])').on('click', function(e) {


            // e.preventDefault()
            $('body').removeClass('page-load')
            var $targetLocation = $(this).attr('href');
            var $timeOutDur = 500;
            if ($targetLocation !== '') {
                setTimeout(function() {
                        window.location = $targetLocation;
                    }, $timeOutDur)
                    return false;

            }

        })

//inputfile

var inputs = document.querySelectorAll( '.inputfile' );
Array.prototype.forEach.call( inputs, function( input )
{
    var label    = input.nextElementSibling,
        labelVal = label.innerHTML;

    input.addEventListener( 'change', function( e )
    {
        var fileName = '';
        if( this.files && this.files.length > 1 )
            fileName = ( this.getAttribute( 'data-multiple-caption' ) || '' ).replace( '{count}', this.files.length );
        else
            fileName = e.target.value.split( '\\' ).pop();

        if( fileName )
            label.querySelector( 'span' ).innerHTML = fileName;
        else
            label.innerHTML = labelVal;
    });
});

// scroll efect

    var header = $('.wpc-start-block header');
    var range = 200;

    $(window).on('scroll', function() {

        var scrollTop = $(this).scrollTop();
        var offset = header.offset().top;
        var height = header.outerHeight();
        offset = offset + height / 2;
        var calc = 1 - (scrollTop - offset + range) / range;

        header.css({ 'opacity': calc });


        if (calc > '1') {
            header.css({ 'opacity': 1 });
        } else if (calc < '0') {
            header.css({ 'opacity': 0 });
        }

    });






    $('.wpc-content-wrap ').css('min-height', $(window).height() - ($('.wpc-footer').outerHeight()))



    // range slider


    function initSliderUI() {
        if ($("#slider1").length) {

            // Store the locked state and slider values.
            var slider1 = document.getElementById('slider1'),
                slider1Value = document.querySelector('.wpc-range-slider  span');

            noUiSlider.create(slider1, {
                start: 0,

                // Disable animation on value-setting,
                // so the sliders respond immediately.
                animate: false,
                range: {
                    min: 0,
                    max: 233
                }
            });



            slider1.noUiSlider.on('update', function(values, handle) {
                slider1Value.innerHTML = values[handle];
                console.log(values);

            });


        }


    }


    


    ///////////////////////////////
    // Accordion
    ///////////////////////////////

    var wpcRemoveClass = function(el, _class) {
        if (el.classList)
            el.classList.remove(_class ? _class : 'active');
        else
            el.className = panel.className.replace(new RegExp('(^|\\b)' + className.split(' ').join('|') + '(\\b|$)', 'gi'), ' ');
    }
    $('.wpc-accordion').on('click', '.panel-title', function() {

        var panel_parent = this.parentNode,
            panel_container = panel_parent.parentNode,
            panels_wrap = panel_container.querySelectorAll('.panel-wrap');
        var panel_title = $('.panel-title');
        $(this).toggleClass('fa-minus-circle')
        Array.prototype.forEach.call(panels_wrap, function(panel, i) {
            if (panel !== panel_parent) {
                wpcRemoveClass(panel);
            }
        });

        if (-1 !== this.parentNode.className.indexOf('active')) {
            wpcRemoveClass(panel_parent);
        } else {
            panel_parent.className += ' active';
        }

    });




    ///////////////////////////////
    // Pop up
    ///////////////////////////////
    $('.wpc-info-label a').on('click', function(event) {
        event.preventDefault();
    });
    $('.popup-with-form').magnificPopup({
        type: 'inline',
        preloader: false,
        focus: '#name',

        // When elemened is focused, some mobile browsers in some cases zoom in
        // It looks not nice, so we disable it:
        callbacks: {
            beforeOpen: function() {
                if ($(window).width() < 700) {
                    this.st.focus = false;
                } else {
                    this.st.focus = '#name';
                }
            }
        }
    });

    ///////////////////////////////
    // Tabs

    ///////////////////////////////
    $('.tabs-header').on('click', 'li:not(.active)', function(e) {
        e.preventDefault();

        var index_el = $(this).index();

        $(this).addClass('active').siblings().removeClass('active');
        $(this).closest('.tabs').find('.tabs-item').hide().removeClass('active').eq(index_el).fadeIn().addClass('active');

    });
    ///////////////////////////////
    // selectpicker

    ///////////////////////////////
    if ($('.selectpicker').length) {

        $('.selectpicker').selectpicker({
            style: 'btn-info',
            size: 4
        });
    }

    ////////////////////////////
    // menu
    ////////////////////////////////
    $('.menu-item-has-children > a').append('<span class="fa fa-angle-down"></span>');

    $('.nav-menu-icon').on('click', function(e) {
        $(this).toggleClass('active');
        $('.wpc-navigation').toggleClass('active');
    });

    $('.menu-item-has-children a').on('click', function(event) {

        event.preventDefault();
        var that = $(this)
        that.closest('li').siblings('.menu-item.menu-item-has-children').find('.sub-menu').slideUp();
        that.closest('li').siblings('.menu-item.menu-item-has-children').find('.wpc-open-menu').removeClass('wpc-open-menu')
        that.next().slideToggle()

        that.toggleClass('wpc-open-menu')
    });



    ////////////////////////////////////////////////////////////

    ////////////////////////////////
    // backround block with image
    function wpc_add_img_bg2(img_sel, parent_sel) {

        if (!img_sel) {
            console.info('no img selector');
            return false;
        }
        var $parent, _this;

        $(img_sel).each(function() {
            _this = $(this);
            $parent = _this.closest(parent_sel);
            $parent = $parent.length ? $parent : _this.parent();
            $parent.css('background-image', 'url(' + this.src + ')');
            _this.css('visibility', 'hidden');
        });

    }

    function wpc_add_img_bg(img_sel, parent_sel) {

        if (!img_sel) {
            console.info('no img selector');
            return false;
        }
        var $parent, _this;

        $(img_sel).each(function() {
            _this = $(this);
            $parent = _this.closest(parent_sel);
            $parent = $parent.length ? $parent : _this.parent();
            $parent.css('background-image', 'url(' + this.src + ')');
            _this.hide();
        });

    }

    /*============================*/
    /* Load resize function */
    /*============================*/
    function loadResize() {
        $('.wpc-login-block').height($(window).height())
    }

    /*============================*/
    /* 04 - FUNCTION ON PAGE LOAD */
    /*============================*/

    $(window).on('load ', function() {
        initSliderUI()
            // minContentHeight()
        loadResize();
        wpc_add_img_bg('.wpc-bg-block .wpc-img', '.wpc-bg-block');
        wpc_add_img_bg2('.wpc-bg-block2 .wpc-img', '.wpc-bg-block');

        $('body').addClass('page-load')

    });
    $(window).on('resize', function() {
        loadResize();



    });
    $(window).on('scroll', function() {

    });

})(jQuery, window, document);
