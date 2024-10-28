# DHCPConfChecker
ISC-DHCP-ServerとKeaのMACアドレスによる固定IPの設定に重複がないか調べる

- ISC-DHCP-Serverのdhcpd.conf
- Kea-DHCPの設定ファイル (reservationsのオブジェクト部分のみ)
- ISC-DHCP-ServerのLDAP

## できること

- ホスト名の重複チェック
- IPアドレスの重複チェック
- MACアドレスの重複チェック
- ホスト、IPアドレス、MACアドレスの一覧のCSV出力

## 動作環境

- Windows 10, Windows 11
- .NET Framework 4.8.1
