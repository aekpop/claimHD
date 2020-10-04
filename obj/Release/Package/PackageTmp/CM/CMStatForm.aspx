<%@ Page Title="STAT CM" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CMStatForm.aspx.cs" Inherits="ClaimProject.CM.CMStatForm" layout ="null" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          
                <div class="card">
                    <div id="chartContainer" style="height: 370px; width: 50%;"></div>
                    <div id="chartContainer2" style="height: 370px; width: 50%;"></div>
                    <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
                </div>

            <script>
                    window.onload = function () {

                    var result = @Html.Raw(ViewBag.DataPoints);
                            var dataPoints =[];
                            for(var i = 0; i < result.length; i++){
	                            dataPoints.push({x:result[i].x, y:result[i].y});
                            }
 
                            var chart = new CanvasJS.Chart("chartContainer", {
                                animationEnabled: true,
                                title: {
                                    text: "ASP.NET MVC Column Chart from Database"
                                },
                                data: [
                                {
                                    type: "column",
                                    dataPoints: dataPoints,
                                }
                                ]
                            });
                            chart.render();

                        var chartcr = new CanvasJS.Chart("chartContainer2", {
	                        animationEnabled: true,
	                        title:{
		                        text: "Email Categories",
		                        horizontalAlign: "left"
	                        },
	                        data: [{
		                        type: "doughnut",
		                        startAngle: 60,
		                        //innerRadius: 60,
		                        indexLabelFontSize: 17,
		                        indexLabel: "{label} - #percent%",
		                        toolTipContent: "<b>{label}:</b> {y} (#percent%)",
		                        dataPoints: [
			                        { y: 67, label: "Inbox" },
			                        { y: 28, label: "Archives" },
			                        { y: 10, label: "Labels" },
			                        { y: 7, label: "Drafts"},
			                        { y: 15, label: "Trash"},
			                        { y: 6, label: "Spam"}
		                        ]
	                        }]
                        });
                        chartcr.render();
                    }
        </script>     
 </asp:content>
