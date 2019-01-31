﻿using EInfrastructure.Core.AutoConfig.Extension;
using EInfrastructure.Core.HelpCommon;
using EInfrastructure.Core.Interface.IOC;
using EInfrastructure.Core.Interface.Storage;
using EInfrastructure.Core.Interface.Storage.Param.Pictures;
using EInfrastructure.Core.QiNiu.Storage.Config;
using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;

namespace EInfrastructure.Core.QiNiu.Storage
{
    /// <summary>
    /// 图片服务
    /// </summary>
    public class PictureService : BaseStorageProvider, IPictureService, ISingleInstance
    {
        /// <summary>
        /// 图片服务
        /// </summary>
        /// <param name="qiNiuSnapshot">七牛配置</param>
        public PictureService(IWritableOptions<QiNiuConfig> qiNiuSnapshot) :
            base(qiNiuSnapshot.Get<QiNiuConfig>())
        {
        }

        #region 根据图片base64上传

        /// <summary>
        /// 根据图片base64上传
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool Upload(UploadByBase64Param param)
        {
            SetPutPolicy(param.ImgPersistentOps.Key, param.ImgPersistentOps.IsAllowOverlap,
                "");
            string token = Auth.CreateUploadToken(Mac, PutPolicy.ToJsonString());
            FormUploader target = new FormUploader(GetConfig());
            HttpResult result =
                target.UploadData(param.Base64.ConvertToByte(), param.ImgPersistentOps.Key, token,
                    GetPutExtra());
            return result.Code == (int) HttpCode.OK;
        }

        #endregion
    }
}