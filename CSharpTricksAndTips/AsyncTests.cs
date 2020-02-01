using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTricksAndTips
{
    /***
     * https://medium.com/rubrikkgroup/understanding-async-avoiding-deadlocks-e41f8f2c6f5d
     * 
     */
    public class AsyncTests
    {
        public String DownloadStringV3(String url)
        {
            // NOT SAFE, instant deadlock when called from UI thread
            // deadlock when called from threadpool, works fine on console
            var request = new HttpClient().GetAsync(url).Result;
            var download = request.Content.ReadAsStringAsync().Result;
            return download;
        }

        public String DownloadStringV4(String url)
        {
            // NOT SAFE, deadlock when called from threadpool
            // works fine on UI thread or console main 
            return Task.Run(async () => {
                var request = await new HttpClient().GetAsync(url);
                var download = await request.Content.ReadAsStringAsync();
                return download;
            }).Result;
        }

        public String DownloadStringV5(String url)
        {
            // REALLY REALLY BAD CODE,
            // guaranteed deadlock 
            return Task.Run(() => {
                var request = new HttpClient().GetAsync(url).Result;
                var download = request.Content.ReadAsStringAsync().Result;
                return download;
            }).Result;
        }
    }
}
