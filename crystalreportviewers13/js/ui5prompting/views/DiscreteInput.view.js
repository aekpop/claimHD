'use strict'
jQuery.sap.require("ui5prompting.inputs.InputRow");
jQuery.sap.require("ui5prompting.utils.ModelPathBuilder");
jQuery.sap.require("ui5prompting.views.PromptComponentViews");

sap.ui.jsview("ui5prompting.views.DiscreteInput", {

    getControllerName: function() {
        return "ui5prompting.controllers.DiscreteInput";
    },

    createContent: function(oController) {
        var viewData = this.getViewData();
        this.oInputRow = CreateDiscreteInput({
            promptData: viewData.promptData,
            options: viewData.options,
            viewerName: viewData.viewerName,
            valueState: {
                path: ModelPathBuilder.BuildFullViewPath(ModelPathBuilder.VIEW_VALIDATION, viewData.promptData, viewData.viewerName),
                formatter: function(value) {
                    if (value) {
                        return sap.ui.core.ValueState.Success;
                    } else {
                        return sap.ui.core.ValueState.Error;
                    }
                }
            },
            basePromptController: oController
        });
        this.getInput().attachValueChange(oController.onSubmit.bind(oController));

        return new PromptPanel({
            headerText: viewData.promptData.fDescription,
            content: this.oInputRow,
            expandable: true,
            expanded: '{' + ModelPathBuilder.BuildFullViewPath(ModelPathBuilder.VIEW_EXPANDED, viewData.promptData, viewData.viewerName) + '}',
            selected: '{' + ModelPathBuilder.BuildFullViewPath(ModelPathBuilder.VIEW_SELECTED, viewData.promptData, viewData.viewerName) + '}'
        });
    },

    getInput: function() {
        return this.oInputRow.getInput();
    }
});