﻿@Code
    ViewData("Title") = "Detecting WCPP for Raw Data Print in ASP.NET"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@section MyHead
    @* WCPP-detection meta tag for IE10 *@
    @Html.Raw(Neodynamic.SDK.Web.WebClientPrint.GetWcppDetectionMetaTag())
end section

<div class="container">
    <div id="msgInProgress">
        <div class="row">
            <div class="span1">
                <img src="@Url.Content("~/Content/InProgress.gif")" alt="In Progress..." />
            </div>
            <div class="span8">
                Detecting WCPP utility at client side.
                <br />
                Please wait a few seconds...
                <br />
            </div>
        </div>
    </div>
    <div id="msgInstallWCPP" style="display:none;">
        <div class="row">
            <div class="span9">
                <h3>#1 Install WebClientPrint Processor (WCPP) 2.0!</h3>
                <p>
                    <strong>WCPP is a native app (without any dependencies!)</strong> that handles all print jobs
                    generated by the <strong>WebClientPrint ASP.NET component</strong> at the server side. The WCPP
                    is in charge of the whole printing process and can be
                    installed on <strong>Windows, Linux &amp; Mac!</strong>
                </p>
                <p>
                    <a class="btn btn-success" href="http://www.neodynamic.com/downloads/wcpp/" target="_blank">Download and Install WCPP from Neodynamic website</a><br />
                </p>

                <h3>#2 After installing WCPP...</h3>
                <p>
                    <a href="@Url.Action("samples", "home")">You can go and test WebClientPrint for ASP.NET</a>
                </p>
            </div>
        </div>
    </div>


</div>


@section MyScript

    <script type="text/javascript">

        var wcppPingDelay_ms = 5000;

        function wcppDetectOnSuccess(){
            @* WCPP utility is installed at the client side
                 redirect to WebClientPrint sample page *@

            @* get WCPP version *@
            var wcppVer = arguments[0];
            if(wcppVer.substring(0, 1) == "2")
                window.location.href = "@Url.Action("samples", "home")";
            else //force to install WCPP v2.0
                wcppDetectOnFailure();

        }

        function wcppDetectOnFailure() {
            @* It seems WCPP is not installed at the client side
                 ask the user to install it *@
            $('#msgInProgress').hide();
            $('#msgInstallWCPP').show();
        }


    </script>


    @* WCPP detection script *@
    @Html.Raw(Neodynamic.SDK.Web.WebClientPrint.CreateWcppDetectionScript())

end section
