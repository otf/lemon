lemon - Functional Http Handler
===

HTTP で XML をやり取りするような簡単な WebAPI を構築するとしましょう。
ASP.NET や WCF はどうでしょうか？
複雑な Web.config や、使いづらい HttpRequest や型安全でない UriTemplate はいつでも私たちを悩ませます。
lemon はこのようなコンテキストに対して最適なソリューションです。

特徴
---
このライブラリを使うことで下記のようなメリットが得られます。
・シンプルな Web.config

    <?xml version="1.0"?>
    <configuration>
        <system.web>
          <httpHandlers>
            <add verb="*" path="*" type="LemonHandler" />
          </httpHandlers>
        <system.web>
    </configuration>
これは、たった8行の1度だけ書けばよいWeb.configです。

* 関数による Server の定義

    [<Export>]
    let (server:Server) = function
      | GET (url , headers) -> response "12" >> ok >> setHeader "content-type" "text/plain"
      | POST (url, headers, body) -> readXml body |> xmlResponse
      | _ -> ok

* HTTP Request に対してのパターンマッチ
* コンビネータによる簡単な HTTP Response の生成
* .NET Framework 2.0で動作します。（未実装）
