package com.houbank.framework.versionmanager.contract;

import javax.validation.constraints.NotNull;

/**
 * Created by HouBank on 2018/1/9.
 */
public class PrimaryKeyRequest {
    @NotNull(message = "id 不能为空")
    private Long id;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }
}
