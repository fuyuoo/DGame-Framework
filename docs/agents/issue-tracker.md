# 任务跟踪：GitHub

任务和规格存放于 `fuyuoo/DGame-Framework` 的 GitHub Issues。
使用 `gh` CLI，并显式指定 `--repo fuyuoo/DGame-Framework`。

## 常用操作

- 创建：`gh issue create --repo fuyuoo/DGame-Framework --title "标题" --body-file <文件>`
- 读取：`gh issue view <编号> --repo fuyuoo/DGame-Framework --comments`
- 列表：`gh issue list --repo fuyuoo/DGame-Framework --state open --json number,title,body,labels`
- 评论：`gh issue comment <编号> --repo fuyuoo/DGame-Framework --body-file <文件>`
- 标签：`gh issue edit <编号> --repo fuyuoo/DGame-Framework --add-label "<标签>"`；移除使用 `--remove-label`
- 关闭：`gh issue close <编号> --repo fuyuoo/DGame-Framework`

多行正文先写入临时文件，再使用 `--body-file`。
发布、评论、标签修改和关闭等写操作遵守当前用户授权及仓库规则。
本配置仅定义工作约定，不构成外部写入授权。

## PR 请求入口

**PRs as a request surface: no.**

## 技能约定

“发布到任务跟踪器”表示创建 GitHub Issue。
“获取相关任务”表示读取 Issue 正文、评论和标签。

## Wayfinder

- 地图：单个 Issue，标签 `wayfinder:map`，正文记录笔记、已定决策和未知问题。
- 子任务：优先使用 GitHub sub-issues；不可用时在地图正文维护任务列表，子任务正文注明 `Part of #<地图编号>`。
- 类型标签：`wayfinder:research`、`wayfinder:prototype`、`wayfinder:grilling`、`wayfinder:task`。
- 阻塞关系：优先使用 GitHub 原生 Issue dependencies；不可用时，子任务正文注明 `Blocked by: #<编号>`。
- 可领取任务：地图中按顺序排列、未关闭、无未关闭阻塞项且未分配的首个子任务。
- 领取：分配给当前开发者。
- 完成：发布结果、关闭子任务，并在地图中追加结论及来源链接。
